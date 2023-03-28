using System.ComponentModel.DataAnnotations;

namespace WebHotel.Model.Token
{
    public class TokenRequest
    {
        [Required]
        public string? AccessToken { get; set; }
        [Required]
        public string? RefreshToken { get; set; }
    }
}
