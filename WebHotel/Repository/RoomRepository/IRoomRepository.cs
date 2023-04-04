using WebHotel.DTO;
using WebHotel.DTO.RoomDtos;

namespace WebHotel.Repository.RoomRepository
{
    public interface IRoomRepository
    {
        Task<IEnumerable<RoomResponseDto>> GetAll();
        Task<IEnumerable<RoomResponseDto>> GetAllBy(DateTime? checkIn, DateTime? checkOut, decimal? price, int? typeRoomId, float? star, int? peopleNumber);
        RoomResponseDto GetById(string id);
        //bool update(RoomResponseDto roomResponseDto);
        Task<StatusDto> Create(RoomCreateDto roomCreateDto);
    }
}
