using System.ComponentModel.DataAnnotations;

namespace BusStation.Data.DataTransferObjects.Admin
{
    public class ChangePasswordDTO
    {
        [Required(ErrorMessage = "Old password is required field.")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "New password is required field.")]
        public string NewPassword { get; set; }
    }
}
