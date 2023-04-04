namespace WebHotel.DTO.DiscountRoomDetailDtos
{
    public class DiscountRoomDetailRequest
    {
        public string RoomId { get; set; } = null!;

        public int DiscountId { get; set; }

        public string CreatorUserName { get; set; } = null!;
    }
}
