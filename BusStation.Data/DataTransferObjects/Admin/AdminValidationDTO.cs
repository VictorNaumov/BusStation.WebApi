using System.ComponentModel.DataAnnotations;

namespace BusStation.Data.DataTransferObjects.Admin
{
    public class AdminValidationDTO
    {
        [Required(ErrorMessage = "Username is required field.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required field.")]
        public string Password { get; set; }
    }
}
