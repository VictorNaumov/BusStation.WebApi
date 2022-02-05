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
        public string MinPrice { get; set; }
        public string MaxPrice { get; set; }
    }
}
