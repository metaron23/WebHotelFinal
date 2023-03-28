using System.ComponentModel.DataAnnotations;

namespace WebHotel.Model.Authentication
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        public string? ClientURI { get; set; }
    }
}
