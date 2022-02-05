import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { connectionString } from "src/app/shared/constants/connection.constants";
import { RouteBusStopIncomingDTO } from "../models/incoming/route-bus-stop-incoming-dto";
import { RouteBusStopOutgoingDTO } from "../models/outgoing/route-bus-stop-outgoing-dto";

@Injectable({ providedIn: 'root' })
export class RouteBusStopService {
    public pathBase: string = `${connectionString}/routeBusStop`;

    constructor(private http: HttpClient) { }

    public GetAllRouteBusStops(): Observable<RouteBusStopIncomingDTO[]> {
        return this.http.get<RouteBusStopIncomingDTO[]>(this.pathBase);
    }

    public GetRouteBusStopById(routeId: number, busStopId: number, order: number): Observable<RouteBusStopIncomingDTO> {
        return this.http.get<RouteBusStopIncomingDTO>(`${this.pathBase}/${routeId}`);
    }

    public CreateRouteBusStop(routeBusStop: RouteBusStopOutgoingDTO): Observable<RouteBusStopIncomingDTO> {
        return this.http.post<RouteBusStopIncomingDTO>(`${this.pathBase}`, routeBusStop);
    }

    public UpdateRouteBusStop(routeBusStopId: number, routeBusStop: RouteBusStopOutgoingDTO): Observable<RouteBusStopIncomingDTO> {
        return this.http.put<RouteBusStopIncomingDTO>(`${this.pathBase}/${routeBusStopId}`, routeBusStop);
    }

    public DeleteRouteBusStop(routeBusStopId: number): Observable<any> {
        return this.http.delete<any>(`${this.pathBase}/${routeBusStopId}`);
    }
}
