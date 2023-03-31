using AutoMapper;
using WebHotel.DTO.RoomDtos;
using WebHotel.DTO.Token;
using WebHotel.DTO.UserDtos;
using WebHotel.Model;

namespace WebHotel.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<TokenRequestDto, TokenResponseDto>().ReverseMap();
            CreateMap<UserProfileRequestDto, ApplicationUser>().ReverseMap();
            CreateMap<UserProfileResponseDto, ApplicationUser>().ReverseMap();
            CreateMap<RoomResponseDto, Room>().ReverseMap();
        }
    }
}
