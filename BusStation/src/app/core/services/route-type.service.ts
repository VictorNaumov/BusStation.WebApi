import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { connectionString } from "src/app/shared/constants/connection.constants";
import { RouteTypeIncomingDTO } from "../models/incoming/route-type-incoming-dto";

@Injectable({ providedIn: 'root' })
export class RouteTypeService {
    public pathBase: string = `${connectionString}/routeType`;

    constructor(private http: HttpClient) { }

    public GetAllRouteTypes(): Observable<RouteTypeIncomingDTO[]> {
        return this.http.get<RouteTypeIncomingDTO[]>(this.pathBase);
    }

    public GetRouteTypeById(id: number): Observable<RouteTypeIncomingDTO> {
        return this.http.get<RouteTypeIncomingDTO>(`${this.pathBase}/${id}`);
    }
}
