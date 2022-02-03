import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { connectionString } from "src/app/shared/constants/connection.constants";
import { getUrl } from "src/app/shared/functions/getUrl";
import { BusIncomingDTO } from "../models/incoming/bus-incoming-dto";
import { BusOutgoingDTO } from "../models/outgoing/bus-outgoing-dto";
import { BusParameters } from "../models/utility/bus-parameters";

@Injectable({ providedIn: 'root' })
export class BusService {
    public pathBase: string = `${connectionString}/bus`;

    constructor(private http: HttpClient) { }

    public GetAllBuses(parameters: BusParameters): Observable<BusIncomingDTO[]> {
        return this.http.get<BusIncomingDTO[]>(getUrl(this.pathBase, parameters));
    }

    public GetBusById(id: number): Observable<BusIncomingDTO> {
        return this.http.get<BusIncomingDTO>(`${this.pathBase}/${id}`);
    }

    public CreateBus(bus: BusOutgoingDTO): Observable<BusIncomingDTO> {
        return this.http.post<BusIncomingDTO>(`${this.pathBase}`, bus);
    }

    public UpdateBus(busId: number, bus: BusOutgoingDTO): Observable<BusIncomingDTO> {
        return this.http.put<BusIncomingDTO>(`${this.pathBase}/${busId}`, bus);
    }

    public DeleteBus(busId: number): Observable<any> {
        return this.http.delete<any>(`${this.pathBase}/${busId}`);
    }
}
