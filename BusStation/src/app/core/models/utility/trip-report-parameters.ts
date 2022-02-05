import { RequestParameters } from "./request-parameters";

export interface TripReportParameters extends RequestParameters {
   ScheduleName?: string,
   RouteTypeName?: string,
   MinPrice?: number,
   MaxPrice?: string
}
