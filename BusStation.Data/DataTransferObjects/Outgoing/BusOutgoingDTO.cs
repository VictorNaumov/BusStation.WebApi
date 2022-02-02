namespace BusStation.Data.DataTransferObjects.Outgoing
{
    public class BusOutgoingDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Driver { get; set; }
        public int CountOfSeats { get; set; }
    }
}
