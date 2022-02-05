import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject, throwError } from "rxjs";
import { catchError, tap } from "rxjs/operators";
import { Router } from "@angular/router";
import { connectionString } from "src/app/shared/constants/connection.constants";
import { AdminValidationDTO } from "../models/admin/admin-validation-dto";
import { AdminRegistrationDTO } from "../models/admin/admin-registration-dto";
import { getUrl } from "src/app/shared/functions/getUrl";
import { AdminRegistrationParameters } from "../models/utility/admin-registration-parameters";

@Injectable({ providedIn: 'root' })
export class AuthService {

    public error$: Subject<string> = new Subject<string>();
    public pathBase: string = `${connectionString}/account/`;

    constructor(
        private http: HttpClient,
        private router: Router) { }

    get token(): string | null {
        const expiresDate = new Date(String(localStorage.getItem('token-exp')));
        if (new Date() > expiresDate) {
            this.logout();
            return null;
        }
        return localStorage.getItem('token');
    }
    public login(user: AdminValidationDTO): Observable<any> {
      return this.http.post(`${this.pathBase}login`, user).pipe(
        tap((result: any) => this.setToken(result)),
        catchError(this.handleError.bind(this))
      );
    }

    public signup(user: AdminRegistrationDTO, parameters: AdminRegistrationParameters): Observable<any> {
      return this.http.post(getUrl(`${this.pathBase}`, parameters) , user).pipe(
        tap((result: any) => this.setToken(result)),
        catchError(this.handleError.bind(this))
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

    private handleError(error: HttpErrorResponse): Observable<never> {
      const {message} = error.error;
      switch (message) {
        case 'INVALID_EMAIL':
          this.error$.next('Wrong email');
          break;
        case 'INVALID_PASSWORD':
          this.error$.next('Wrong password');
          break;
        case 'EMAIL_NOT_FOUND':
          this.error$.next('Nonexistent email');
          break;
      }
      return throwError(error);
    }
}
