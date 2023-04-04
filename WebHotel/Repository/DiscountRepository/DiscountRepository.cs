using AutoMapper;
using WebHotel.Data;
using WebHotel.DTO;
using WebHotel.DTO.DiscountDtos;
using WebHotel.Models;

namespace WebHotel.Repository.DiscountRepository
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly MyDBContext _context;
        private readonly IMapper _mapper;

        public DiscountRepository(MyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<StatusDto> Create(DiscountRequestDto discountRequestDto)
        {
            var user = _context.ApplicationUsers.SingleOrDefault(a => a.UserName == discountRequestDto.CreatorUserName);
            if (user != null)
            {
                var discount = _mapper.Map<Discount>(discountRequestDto);
                discount.CreatorId = user.Id;
                try
                {
                    await _context.AddAsync(discount);
                    await _context.SaveChangesAsync();
                    return new StatusDto { StatusCode = 1, Message = "Created successfully" };
                }
                catch { }
            }
            return new StatusDto { StatusCode = 0, Message = "Create discount error" };
        }
    }
}
