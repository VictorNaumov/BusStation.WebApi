using System.Collections.Generic;

namespace BusStation.Data.DataTransferObjects.Outgoing
{
    public class RouteOutgoingDTO
    {
        public int Id { get; set; }
        public string ArrivalBusStop { get; set; }
        public string DepartureBusStop { get; set; }
        public string RouteType { get; set; }
        public List<RouteNodeOutgoingDTO> RouteNodes { get; set; }
    }
}
