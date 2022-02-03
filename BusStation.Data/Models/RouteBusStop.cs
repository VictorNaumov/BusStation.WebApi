using System.ComponentModel.DataAnnotations;

namespace BusStation.Data.Models
{
    public class RouteBusStop
    {
        [Required(ErrorMessage = "Order is required field.")]
        [Range(1, int.MaxValue, ErrorMessage = "Order must be positive.")]
        public int Order { get; set; }
        public int MinutesInWay { get; set; }
        public int WaitingTime { get; set; }
        public int BusStopId { get; set; }
        public int RouteId { get; set; }
        public BusStop BusStop { get; set; }
        public Route Route { get; set; }
    }
}
