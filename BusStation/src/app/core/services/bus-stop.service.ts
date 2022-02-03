import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { connectionString } from "src/app/shared/constants/connection.constants";
import { getUrl } from "src/app/shared/functions/getUrl";
import { BusStopIncomingDTO } from "../models/incoming/bus-stop-incoming-dto";
import { BusStopOutgoingDTO } from "../models/outgoing/bus-stop-outgoing-dto";
import { BusStopParameters } from "../models/utility/bus-stop-parameters";

@Injectable({ providedIn: 'root' })
export class BusStopService {
    public pathBase: string = `${connectionString}/busStop`;

    constructor(private http: HttpClient) { }

    public GetAllBusStops(parameters: BusStopParameters): Observable<BusStopIncomingDTO[]> {
        return this.http.get<BusStopIncomingDTO[]>(getUrl(this.pathBase, parameters));
    }

    public GetBusStopById(id: number): Observable<BusStopIncomingDTO> {
        return this.http.get<BusStopIncomingDTO>(`${this.pathBase}/${id}`);
    }

    public CreateBusStop(busStop: BusStopOutgoingDTO): Observable<BusStopIncomingDTO> {
        return this.http.post<BusStopIncomingDTO>(`${this.pathBase}`, busStop);
    }

    public UpdateBusStop(busStopId: number, busStop: BusStopOutgoingDTO): Observable<BusStopIncomingDTO> {
        return this.http.put<BusStopIncomingDTO>(`${this.pathBase}/${busStopId}`, busStop);
    }

    public DeleteBusStop(busStopId: number): Observable<any> {
        return this.http.delete<any>(`${this.pathBase}/${busStopId}`);
    }
}
