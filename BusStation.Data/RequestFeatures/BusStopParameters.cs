namespace BusStation.Data.RequestFeatures
{
    public class BusStopParameters : RequestParameters
    {
        public BusStopParameters()
        {
            OrderBy = "name";
        }

        public string SearchTerm { get; set; }
    }
}
