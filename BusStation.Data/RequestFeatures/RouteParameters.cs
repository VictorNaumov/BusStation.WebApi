namespace BusStation.Data.RequestFeatures
{
    public class RouteParameters : RequestParameters
    {
        public RouteParameters()
        {
            OrderBy = "name";
        }

        public string SearchTerm { get; set; }
        public string DateTime { get; set; }
        public string ArrivalBusStop { get; set; }
        public string DepartureBusStop { get; set; }
        public string RouteType { get; set; }
    }
}
