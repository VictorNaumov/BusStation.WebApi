import { RequestParameters } from "./request-parameters";

export interface TripReportParameters extends RequestParameters {
  arrivalBusStop?: string;
  departureBusStop?: string;
}
