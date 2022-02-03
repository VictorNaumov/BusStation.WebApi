import { RequestParameters } from "./request-parameters";

export interface TripParameters extends RequestParameters {
  minPrice?: number,
  maxPrice?: number
 }
