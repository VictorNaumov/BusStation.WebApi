export interface BusStopForReportIncomingDTO {
  id: number;
  name: string;
  location: string;
  order: number;
  waitingTime: number;
  departureTime: Date;
  arrivalTime: Date;
}
