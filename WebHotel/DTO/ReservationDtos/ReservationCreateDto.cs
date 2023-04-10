using System.ComponentModel.DataAnnotations;

namespace WebHotel.DTO.ReservationDtos
{
    public class ReservationCreateDto
    {
        [Required(ErrorMessage = "{0} is required")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string? RoomId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public float? NumberOfDay { get; set; }
    }
}
