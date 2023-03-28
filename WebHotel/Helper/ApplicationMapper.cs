using AutoMapper;
using WebHotel.Model.Token;

namespace WebHotel.Helper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            CreateMap<TokenRequest, TokenResponse>().ReverseMap();
        }
    }
}
