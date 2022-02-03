import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { connectionString } from "src/app/shared/constants/connection.constants";
import { RouteIncomingDTO } from "../models/incoming/route-incoming-dto";
import { RouteOutgoingDTO } from "../models/outgoing/route-outgoing-dto";

@Injectable({ providedIn: 'root' })
export class RouteService {
    public pathBase: string = `${connectionString}/route`;

    constructor(private http: HttpClient) { }

    public GetAllRoutes(): Observable<RouteIncomingDTO[]> {
        return this.http.get<RouteIncomingDTO[]>(this.pathBase);
    }

    public GetRouteById(id: number): Observable<RouteIncomingDTO> {
        return this.http.get<RouteIncomingDTO>(`${this.pathBase}/${id}`);
    }

    public CreateRoute(route: RouteOutgoingDTO): Observable<RouteIncomingDTO> {
        return this.http.post<RouteIncomingDTO>(`${this.pathBase}`, route);
    }

    public UpdateRoute(routeId: number, route: RouteOutgoingDTO): Observable<RouteIncomingDTO> {
        return this.http.put<RouteIncomingDTO>(`${this.pathBase}/${routeId}`, route);
    }

    public DeleteRoute(routeId: number): Observable<any> {
        return this.http.delete<any>(`${this.pathBase}/${routeId}`);
    }
}
