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
        public string Schedule { get; set; }
        public string RouteType { get; set; }
        public DateTime Date { get; set; }
        public DateTime ArrivalTime { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}
