using Microsoft.AspNetCore.Mvc;
using WebHotel.Repository.RoomRepository;

namespace WebHotel.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public partial class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _roomRepository.GetAll();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> getAllBy(DateTime? checkIn, DateTime? checkOut, decimal? price, int? typeRoomId, float? star, int? peopleNumber)
        {
            var result = await _roomRepository.GetAllBy(checkIn, checkOut, price, typeRoomId, star, peopleNumber);
            return Ok(result);
        }
    }
}
