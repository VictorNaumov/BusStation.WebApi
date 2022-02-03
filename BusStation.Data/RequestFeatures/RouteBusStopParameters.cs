namespace BusStation.Data.RequestFeatures
{
    public class RouteBusStopParameters : RequestParameters
    {
        public RouteBusStopParameters()
        {
            OrderBy = "name";
        }

        public string SearchTerm { get; set; }
        public string ArrivalBusStop { get; set; }
        public string DepartureBusStop { get; set; }
    }
}
