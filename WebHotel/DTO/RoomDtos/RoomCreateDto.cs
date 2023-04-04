using System.ComponentModel.DataAnnotations;

namespace WebHotel.DTO.RoomDtos
{
    public class RoomCreateDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public string RoomNumber { get; set; } = null!;

        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; } = null!;

        public bool? IsActive { get; set; }

        public string? Description { get; set; }

        public string? RoomPicture { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int GuestNumber { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public int RoomTypeId { get; set; }
    }
}
