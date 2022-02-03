import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { connectionString } from "src/app/shared/constants/connection.constants";
import { getUrl } from "src/app/shared/functions/getUrl";
import { TripIncomingDTO } from "../models/incoming/trip-incoming-dto";
import { TripOutgoingDTO } from "../models/outgoing/trip-outgoing-dto";
import { TripParameters } from "../models/utility/trip-parameters";

@Injectable({ providedIn: 'root' })
export class TripService {
    public pathBase: string = `${connectionString}/trip`;

    constructor(private http: HttpClient) { }

    public GetAllTrips(parameters: TripParameters): Observable<TripIncomingDTO[]> {
        return this.http.get<TripIncomingDTO[]>(getUrl(this.pathBase, parameters));
    }

    public GetTripById(id: number): Observable<TripIncomingDTO> {
        return this.http.get<TripIncomingDTO>(`${this.pathBase}/${id}`);
    }

    public CreateTrip(trip: TripOutgoingDTO): Observable<TripIncomingDTO> {
        return this.http.post<TripIncomingDTO>(`${this.pathBase}`, trip);
    }

    public UpdateTrip(tripId: number, trip: TripOutgoingDTO): Observable<TripIncomingDTO> {
        return this.http.put<TripIncomingDTO>(`${this.pathBase}/${tripId}`, trip);
    }

    public DeleteTrip(tripId: number): Observable<any> {
        return this.http.delete<any>(`${this.pathBase}/${tripId}`);
    }
}
