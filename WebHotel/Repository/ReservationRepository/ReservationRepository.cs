using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebHotel.Data;
using WebHotel.DTO;
using WebHotel.DTO.ReservationDtos;
using WebHotel.Models;

namespace WebHotel.Repository.ReservationRepository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public ReservationRepository(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<StatusDto> Create(ReservationCreateDto reservationCreateDto)
        {
            var room = _context.Rooms.AsNoTracking().SingleOrDefault(a => a.Id == reservationCreateDto.RoomId)!;
            var user = _context.Users.AsNoTracking().SingleOrDefault(a => a.UserName == reservationCreateDto.CustomerUserName);
            if (room is not null || user is not null)
            {
                var reservation = _mapper.Map<Reservation>(reservationCreateDto);
                reservation.RoomPrice = room!.CurrentPrice;
                if (room.DiscountPrice == 0)
                {
                    reservation.ReservationPrice = (decimal)room.DiscountPrice;
                }
                else
                {
                    reservation.ReservationPrice = (decimal)room.CurrentPrice;
                }
                //reservation.DepositPrice = reservation.ReservationPrice * (decimal)0.3;
                //var timeSpan = (reservation.StartDate - DateTime.Now).TotalMinutes;
                //if(timeSpan > 60)
                //{
                //    reservation.DepositEndAt = DateTime.Now.AddMinutes(30);
                //}
                //else
                //{

                //}
                reservation.ReservationPrice = (decimal)(room.DiscountPrice == 0 ? 0 : room.DiscountPrice)!;
                await _context.Reservations.AddAsync(reservation);
                await _context.SaveChangesAsync();
                return new StatusDto { StatusCode = 1, Message = "Successful booking" };
            }
            return new StatusDto { StatusCode = 0, Message = "Booking failed" };
        }
    }
}
