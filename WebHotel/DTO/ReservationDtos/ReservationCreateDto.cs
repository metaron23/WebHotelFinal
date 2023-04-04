namespace WebHotel.DTO.ReservationDtos
{
    public class ReservationCreateDto
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string RoomId { get; set; } = null!;

        public string CustomerUserName { get; set; } = null!;
    }
}
