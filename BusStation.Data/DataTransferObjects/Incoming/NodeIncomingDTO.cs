namespace BusStation.Data.DataTransferObjects.Incoming
{
    public class NodeIncomingDTO
    {
        public int MinutesInWay { get; set; }
        public int WaitingTime { get; set; }
        public int Price { get; set; }
        public int FirstBusStopId { get; set; }
        public int SecondBusStopId { get; set; }
    }
}
