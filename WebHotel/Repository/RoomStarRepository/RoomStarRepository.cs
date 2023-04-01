using AutoMapper;
using WebHotel.Data;
using WebHotel.DTO;
using WebHotel.DTO.RoomStarDtos;
using WebHotel.Model;

namespace WebHotel.Repository.RoomStarRepository
{
    public class RoomStarRepository : IRoomStarRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public RoomStarRepository(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StatusDto> Create(RoomStarRequestDto roomStarRequestDto)
        {
            await _context.AddAsync(_mapper.Map<RoomStar>(roomStarRequestDto));
            await _context.SaveChangesAsync();
            return new StatusDto { StatusCode = 1, Message = "Successful comment!" };
        }
    }
}
