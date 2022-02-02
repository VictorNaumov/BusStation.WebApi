using System.Collections.Generic;

namespace BusStation.Data.Models
{
    public class Node
    {
        public int Id { get; set; }
        public int MinutesInWay { get; set; }
        public int WaitingTime { get; set; }
        public int FirstBusStopId { get; set; }
        public int SecondBusStopId { get; set; }
        public BusStop FirstBusStop { get; set; }
        public BusStop SecondBusStop { get; set; }
        public List<RouteNode> RouteNodes { get; set; }
    }
}
