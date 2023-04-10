using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebHotel.DTO;
using WebHotel.DTO.RoomDtos;
using WebHotel.Models;

namespace WebHotel.Repository.RoomRepository
{
    public partial class RoomRepository
    {

        public async Task<StatusDto> Create([FromForm] RoomCreateDto roomCreateDto)
        {
            var room = _mapper.Map<Room>(roomCreateDto);
            try
            {
                if (roomCreateDto.RoomPicture is not null)
                {
                    var checkSendFile = await _fileService.SendFile("Room/" + roomCreateDto.RoomNumber, roomCreateDto.RoomPicture!);
                    if (checkSendFile)
                    {
                        room.RoomPicture = await _fileService.GetFile("Room/" + roomCreateDto.RoomNumber + "/" + roomCreateDto.RoomPicture.FileName);
                    }
                    else
                    {
                        return new StatusDto { StatusCode = 0, Message = "Save room image failed!" };
                    }
                }
                await _context.AddAsync(room);
                await _context.SaveChangesAsync();
                return new StatusDto { StatusCode = 1, Message = "Room created successfully!" };
            }
            catch (DbUpdateException ex)
            {
                return new StatusDto { StatusCode = 0, Message = ex.InnerException?.Message };
            }
        }
    }
}
