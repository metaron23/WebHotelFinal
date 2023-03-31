using AutoMapper;
using WebHotel.Data;
using WebHotel.DTO.RoomDtos;
using WebHotel.Model;

namespace WebHotel.Repository.RoomRepository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public RoomRepository(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //public void checkDiscount()
        //{
        //    _context.Rooms.Select()
        //}

        public async Task<IEnumerable<RoomResponseDto>> getAll()
        {
            var roomsBase = _context.Rooms;
            var roomResponses = new List<RoomResponseDto>();
            roomResponses = roomsBase.Select(_mapper.Map<Room, RoomResponseDto>).ToList();
            return roomResponses;
        }

        public IEnumerable<RoomResponseDto> getAllBy(DateTime? checkIn, DateTime? checkOut, float? price, string? typeRoom, float? Star, int? peopleNumber)
        {
            throw new NotImplementedException();
        }

        public RoomResponseDto getById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
