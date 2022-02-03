using System;

namespace BusStation.Data.DataTransferObjects.Incoming
{
    public class TripIncomingDTO
    {
        public int BusId { get; set; }
        public DateTime DepartureTime { get; set; }
        public int RouteId { get; set; }
        public int ScheduleId { get; set; }
    }
}
