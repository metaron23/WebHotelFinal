using WebHotel.DTO.RoomDtos;

namespace WebHotel.Repository.RoomRepository
{
    public interface IRoomRepository
    {
        Task<IEnumerable<RoomResponseDto>> getAll();
        IEnumerable<RoomResponseDto> getAllBy(DateTime? checkIn, DateTime? checkOut, float? price, string? typeRoom, float? Star, int? peopleNumber);
        RoomResponseDto getById(string id);
        //bool update(RoomResponseDto roomResponseDto);
    }
}
