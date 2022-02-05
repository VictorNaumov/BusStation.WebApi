using System;

namespace BusStation.Data.RequestFeatures
{
    public class TripReportParameters : RequestParameters
    {
        public TripReportParameters()
        {
            OrderBy = "name";
        }

        public string SearchTerm { get; set; }
        public string ScheduleName { get; set; }
        public string RouteTypeName { get; set; }
        public DateTime Date { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}
