namespace BusStation.Data.DataTransferObjects.Outgoing
{
    public class RouteBusStopOutgoingDTO
    {
        public int RouteId { get; set; }
        public int BusStopId { get; set; }
        public int MinutesInWay { get; set; }
        public int WaitingTime { get; set; }
        public int Order { get; set; }
    }
}
