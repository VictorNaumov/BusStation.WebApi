import { RequestParameters } from "./request-parameters";

export interface TripReportParameters extends RequestParameters {
   schedule?: string,
   routeType?: string,
   departureTime?: string,
   arrivalTime?: string,
   date?: string,
}
