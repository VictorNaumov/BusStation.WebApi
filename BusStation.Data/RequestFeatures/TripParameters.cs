namespace BusStation.Data.RequestFeatures
{
    public class TripParameters : RequestParameters
    {
        public TripParameters()
        {
            OrderBy = "name";
        }

        public string SearchTerm { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
    }
}
