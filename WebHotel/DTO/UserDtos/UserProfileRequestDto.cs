using System.ComponentModel.DataAnnotations;

namespace WebHotel.DTO.UserDtos
{
    public class UserProfileRequestDto
    {
        [Required(ErrorMessage = "Email not empty!")]
        [EmailAddress(ErrorMessage = "Email wrong!")]
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public IFormFile? Image { get; set; }
        public string? Address { get; set; }
        public string? CMND { get; set; }
    }
}
