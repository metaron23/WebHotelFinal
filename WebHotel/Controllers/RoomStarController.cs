using Microsoft.AspNetCore.Mvc;
using WebHotel.DTO.RoomStarDtos;
using WebHotel.Repository.RoomStarRepository;

namespace WebHotel.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomStarController : ControllerBase
    {
        private readonly IRoomStarRepository _roomStarRepository;

        public RoomStarController(IRoomStarRepository roomStarRepository)
        {
            _roomStarRepository = roomStarRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoomStarRequestDto roomStarRequestDto)
        {
            return Ok(await _roomStarRepository.Create(roomStarRequestDto));
        }
    }
}
