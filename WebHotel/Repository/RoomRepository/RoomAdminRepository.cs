using WebHotel.DTO;
using WebHotel.DTO.RoomDtos;
using WebHotel.Models;

namespace WebHotel.Repository.RoomRepository
{
    public partial class RoomRepository
    {
        public async Task<StatusDto> Create(RoomCreateDto roomCreateDto)
        {
            var room = _mapper.Map<Room>(roomCreateDto);
            await _context.AddAsync(room);
            try
            {
                await _context.SaveChangesAsync();
                return new StatusDto { StatusCode = 1, Message = "Room created successfully!" };
            }
            catch
            {
                return new StatusDto { StatusCode = 0, Message = "Room created failure!" };
            }
        }
    }
}
