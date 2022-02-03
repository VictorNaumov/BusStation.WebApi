import { HttpClient, HttpHeaders, HttpParamsOptions } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { connectionString } from "src/app/shared/constants/connection.constants";
import { getUrl } from "src/app/shared/functions/getUrl";
import { TripReportIncomingDTO } from "../models/incoming/trip-report-incoming-dto";
import { TripReportParameters } from "../models/utility/trip-report-parameters";

@Injectable({ providedIn: 'root' })
export class TripReportService {
    public pathBase: string = `${connectionString}/tripReport`;

    constructor(private http: HttpClient) {
    }

    public getReportAboutAllTrips(parameters: TripReportParameters): Observable<any> {
        return this.http.get<TripReportIncomingDTO>(getUrl(this.pathBase, parameters));
    }
}
