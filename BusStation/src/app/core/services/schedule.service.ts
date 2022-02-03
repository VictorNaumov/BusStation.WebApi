import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { connectionString } from "src/app/shared/constants/connection.constants";
import { ScheduleIncomingDTO } from "../models/incoming/schedule-incoming-dto";

@Injectable({ providedIn: 'root' })
export class BusService {
    public pathBase: string = `${connectionString}/schedule`;

    constructor(private http: HttpClient) { }

    public GetAllSchedules(): Observable<ScheduleIncomingDTO[]> {
        return this.http.get<ScheduleIncomingDTO[]>(this.pathBase);
    }

    public GetScheduleById(id: number): Observable<ScheduleIncomingDTO> {
        return this.http.get<ScheduleIncomingDTO>(`${this.pathBase}/${id}`);
    }
}
