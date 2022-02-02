using System.Collections.Generic;

namespace BusStation.Data.DataTransferObjects.Outgoing
{
    public class NodeOutgoingDTO
    {
        public int Id { get; set; }
        public int MinutesInWay { get; set; }
        public int WaitingTime { get; set; }
        public int FirstBusStopID { get; set; }
        public int SecondBusStopID { get; set; }
        public string FirstBusStop { get; set; }
        public string SecondBusStop { get; set; }
    }
}
