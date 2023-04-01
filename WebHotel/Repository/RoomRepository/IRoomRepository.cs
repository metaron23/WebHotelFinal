using WebHotel.DTO.RoomDtos;

namespace WebHotel.Repository.RoomRepository
{
    public interface IRoomRepository
    {
        Task<IEnumerable<RoomResponseDto>> getAll();
        Task<IEnumerable<RoomResponseDto>> getAllBy(DateTime? checkIn, DateTime? checkOut, decimal? price, int? typeRoomId, float? star, int? peopleNumber);
        RoomResponseDto getById(string id);
        //bool update(RoomResponseDto roomResponseDto);
    }
}
