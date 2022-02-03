using System;

namespace BusStation.Data.DataTransferObjects.Outgoing
{
    public class TripOutgoingDTO
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public int RouteId { get; set; }
        public int BusId { get; set; }
        public int ScheduleId { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}
