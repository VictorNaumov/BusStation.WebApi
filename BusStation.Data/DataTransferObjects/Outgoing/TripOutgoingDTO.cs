using System;

namespace BusStation.Data.DataTransferObjects.Outgoing
{
    public class TripOutgoingDTO
    {
        public int Id { get; set; }
        public BusOutgoingDTO Bus { get; set; }
        public bool IsBack { get; set; }
        public int RouteId { get; set; }
        public int Price { get; set; }
        public RouteOutgoingDTO Route { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ScheduleDayOutgoingDTO DayOfMovement { get; set; }
    }
}
