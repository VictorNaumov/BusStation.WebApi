using System.Collections.Generic;

namespace BusStation.Data.Models
{
    public class Route
    {
        public int Id { get; set; }
        public int RouteTypeId { get; set; }
        public RouteType RouteType { get; set; }
        public List<RouteNode> RouteNodes { get; set; }
        public List<Trip> Trips { get; set; }
    }
}
