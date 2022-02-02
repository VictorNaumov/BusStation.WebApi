namespace BusStation.Data.RequestFeatures
{
    public class RouteNodeParameters : RequestParameters
    {
        public RouteNodeParameters()
        {
            OrderBy = "name";
        }

        public string SearchTerm { get; set; }
        public string ArrivalBusStop { get; set; }
        public string DepartureBusStop { get; set; }
    }
}
