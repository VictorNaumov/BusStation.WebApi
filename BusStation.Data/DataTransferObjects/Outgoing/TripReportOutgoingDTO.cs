using BusStation.Data.DataTransferObjects.Outgoing;
using System;
using System.Collections.Generic;

namespace BusStation.Data.Models
{
    public class TripReportOutgoingDTO
    {
        public int TripId { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int RouteId { get; set; }
        public int RouteTypeId { get; set; }
        public string RouteType { get; set; }
        public int BusId { get; set; }
        public string BusName { get; set; }
        public string BusDriver { get; set; }
        public string BusNumber { get; set; }
        public int CountOfSeats { get; set; }
        public int ScheduleId { get; set; }
        public string Schedule { get; set; }

        public string DepartureBusStop { get; set; }
        public List<BusStopForReportOutgoingDTO> BusStops { get; set; }
        public string Destination { get; set; }
        public int MinutesInWay { get; set; }
        public int Price { get; set; }
    }
}
