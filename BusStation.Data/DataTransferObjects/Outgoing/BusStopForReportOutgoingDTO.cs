using System;

namespace BusStation.Data.DataTransferObjects.Outgoing
{
    public class BusStopForReportOutgoingDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Order { get; set; }
        public int WaitingTime { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
    }
}
