using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BusStation.Data.Models
{
    public class Bus
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the name is 30 charactesrs.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Number is a required field.")]
        [MaxLength(8, ErrorMessage = "Maximum length for the number is 8 charactesrs.")]
        public string Number { get; set; }
        [Required(ErrorMessage = "Driver is a required field.")]
        [MaxLength(75, ErrorMessage = "Maximum length for the driver is 75 charactesrs.")]
        public string Driver { get; set; }
        [Required(ErrorMessage = "Count of seats is a required field.")]
        [Range(5, 100, ErrorMessage = "Range count of seats is 5 - 100.")]
        public int CountOfSeats { get; set; }
        public List<Trip> Trips { get; set; }
    }
}
