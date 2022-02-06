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

    public GetRouteBusStopById(routeId: number, busStopId: number): Observable<RouteBusStopIncomingDTO> {
        return this.http.get<RouteBusStopIncomingDTO>(`${this.pathBase}/${routeId}/${busStopId}`);
    }

    public CreateRouteBusStop(routeBusStop: RouteBusStopOutgoingDTO): Observable<RouteBusStopIncomingDTO> {
      console.log(routeBusStop);

        return this.http.post<RouteBusStopIncomingDTO>(`${this.pathBase}`, routeBusStop);
    }

    public UpdateRouteBusStop(routeBusStop: RouteBusStopOutgoingDTO): Observable<RouteBusStopIncomingDTO> {
        return this.http.put<RouteBusStopIncomingDTO>(`${this.pathBase}/${routeBusStop.routeId}/${routeBusStop.busStopId}`, routeBusStop);
    }

    public DeleteRouteBusStop(routeId: number, busStopId: number): Observable<any> {
        return this.http.delete<any>(`${this.pathBase}/${routeId}/${busStopId}`);
    }
}
