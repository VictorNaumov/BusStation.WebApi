import { RequestParameters } from "./request-parameters";

export interface BusParameters extends RequestParameters {
  minCountOfSeats?: number;
  maxCountOfSeats?: number;
}
