﻿using Microsoft.AspNetCore.Mvc;
using WebHotel.Repository.RoomRepository;

namespace WebHotel.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;
        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var result = await _roomRepository.getAll();
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> getAllBy(DateTime? checkIn, DateTime? checkOut, decimal? price, int? typeRoomId, float? star, int? peopleNumber)
        {
            var result = await _roomRepository.getAllBy(checkIn, checkOut, price, typeRoomId, star, peopleNumber);
            return Ok(result);
        }
    }
}