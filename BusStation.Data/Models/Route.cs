using System.Collections.Generic;

namespace BusStation.Data.Models
{
    public class Route
    {
        public int Id { get; set; }
        public int RouteTypeId { get; set; }
        public RouteType RouteType { get; set; }
        public ICollection<BusStop> BusStops { get; set; }
        public List<RouteBusStop> RouteBusStops { get; set; }
    }
}
