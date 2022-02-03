import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { tap } from "rxjs/operators";
import { Router } from "@angular/router";
import { connectionString } from "src/app/shared/constants/connection.constants";
import { AdminValidationDTO } from "../models/admin/admin-validation-dto";

@Injectable({ providedIn: 'root' })
export class AuthService {

    public error$: Subject<string> = new Subject<string>();
    public pathBase: string = `${connectionString}/account`;

    constructor(
        private http: HttpClient,
        private router: Router) { }

    get token(): string | null {
        const expiresDate = new Date(String(localStorage.getItem('token-exp')));
        if (new Date() > expiresDate) {
            this.logout();
            return null;
        }
        return localStorage.getItem('fb-token');
    }

    login(authAccount: AdminValidationDTO): Observable<any> {
        return this.http.post(`${this.pathBase}/login`, authAccount)
            .pipe(
                tap((token: any) => this.setToken(token))
            );
    }

    logout() {
        this.setToken(null);
        this.router.navigate(['']);
    }

    isAuthenticated(): boolean {
        return !!this.token;
    }

    private setToken(token: string | null) {
        if (token) {
            const expiresDate = new Date(new Date().getTime() + 60 * 60 * 1000);
            localStorage.setItem('token', token);
            localStorage.setItem('token-exp', expiresDate.toString());
        } else {
            localStorage.clear();
        }
    }
}
