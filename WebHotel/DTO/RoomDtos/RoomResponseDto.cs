namespace WebHotel.DTO.RoomDtos
{
    public class RoomResponseDto
    {
        public string RoomNumber { get; set; } = null!;

        public string Name { get; set; } = null!;

        public bool? IsActive { get; set; }

        public string? Description { get; set; }

        public string? RoomPicture { get; set; }

        public int? StarAmount { get; set; }

        public float? StarSum { get; set; }

        public bool? GuestNumber { get; set; }

        public decimal CurrentPrice { get; set; }

        public decimal? DiscountPrice { get; set; }

        public string? RoomTypeName { get; set; }
    }
}
