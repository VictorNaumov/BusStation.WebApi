namespace BusStation.Data.RequestFeatures
{
    public class BusParameters : RequestParameters
    {
        public BusParameters()
        {
            OrderBy = "name";
        }

        public string SearchTerm { get; set; }
        public double MinCountOfSeats { get; set; }
        public double MaxCountOfSeats { get; set; } = double.MaxValue;
    }
}
