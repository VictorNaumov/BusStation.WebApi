using System;

namespace BusStation.Data.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public DateTime DepartureTime { get; set; }
        public int BusId { get; set; }
        public int RouteId { get; set; }
        public int ScheduleId { get; set; }
        public Bus Bus { get; set; }
        public Route Route { get; set; }
        public Schedule Schedule { get; set; }
    }
}
