using BusStation.Data.Models;
using System;

namespace BusStation.Data.DataTransferObjects.Incoming
{
    public class TripIncomingDTO
    {
        public int BusId { get; set; }
        public DateTime StartTime { get; set; }
        public int RouteId { get; set; }
        public int DayOfMovementId { get; set; }
    }
}
