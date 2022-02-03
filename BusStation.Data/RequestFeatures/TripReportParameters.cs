namespace BusStation.Data.RequestFeatures
{
    public class TripReportParameters : RequestParameters
    {
        public TripReportParameters()
        {
            OrderBy = "name";
        }

        public string SearchTerm { get; set; }
        public string ArrivalBusStop { get; set; }
        public string DepartureBusStop { get; set; }
    }
}
