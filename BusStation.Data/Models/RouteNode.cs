using System.ComponentModel.DataAnnotations;

namespace BusStation.Data.Models
{
    public class RouteNode
    {
        public int Id { get; set; }
        public int RouteId { get; set; }
        public int NodeId { get; set; }
        public Route Route { get; set; }
        public Node Node { get; set; }
        [Required(ErrorMessage = "Name is a required field.")]
        [Range(1, int.MaxValue, ErrorMessage = "Order must be positive.")]
        public int Order { get; set; }
    }
}
