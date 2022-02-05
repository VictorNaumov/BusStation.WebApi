import { BusStopForReportIncomingDTO } from "./bus-stop-for-report-incoming-dto";

export interface TripReportIncomingDTO {
  tripId: number;
  departureTime: Date;
  arrivalTime: Date;
  routeId: number;
  routeTypeId: number;
  routeType: string;
  busId: number;
  busName: string;
  busDriver: string;
  busNumber: string;
  countIfSeats: number;
  scheduleId: number;
  schedule: string;
  busStops: BusStopForReportIncomingDTO[];
  departureBusStop: string;
  destination: string;
  minutesInWay: number;
  price: number;
}
