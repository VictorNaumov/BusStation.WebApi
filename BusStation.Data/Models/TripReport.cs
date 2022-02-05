using System;

namespace BusStation.Data.Models
{
    public class TripReport
    {
        public int TripId { get; set; }
        public DateTime DepartureTime { get; set; }
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
    }
}
