namespace BusStation.Data.DataTransferObjects.Outgoing
{
    public class RouteNodeOutgoingDTO
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int NodeId { get; set; }
        public RouteOutgoingDTO Route { get; set; }
        public NodeOutgoingDTO Node { get; set; }
        public int Order { get; set; }
    }
}
