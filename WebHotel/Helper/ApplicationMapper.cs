using AutoMapper;
using WebHotel.DTO.Token;

namespace WebHotel.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<TokenRequestDto, TokenResponseDto>().ReverseMap();
        }
    }
}
