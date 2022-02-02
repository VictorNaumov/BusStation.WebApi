using System.ComponentModel.DataAnnotations;

namespace BusStation.Data.Models
{
    public class BusStop
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the name is 60 charactesrs.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Name is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the name is 60 charactesrs.")]
        public string Location { get; set; }
    }
}
