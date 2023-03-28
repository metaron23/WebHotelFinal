using System.ComponentModel.DataAnnotations;

namespace WebHotel.Model.Authentication
{
    public class ChangePasswordModel
    {
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? NewPassword { get; set; }
        [Required]
        [Compare("NewPassword")]
        public string? ConfirmNewPassword { get; set; }
    }
}
