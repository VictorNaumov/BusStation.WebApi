using System;

namespace BusStation.Data.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public Bus Bus { get; set; }
        public bool IsBack { get; set; }
        public int RouteId { get; set; }
        public Route Route { get; set; }
        public DateTime StartTime { get; set; }
        public ScheduleDay DayOfMovement { get; set; }
    }
}
