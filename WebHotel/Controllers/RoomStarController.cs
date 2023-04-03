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
            var result = await _roomStarRepository.Create(roomStarRequestDto);
            if (result.StatusCode == 1)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
