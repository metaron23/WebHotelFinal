using WebHotel.DTO;
using WebHotel.DTO.UserDtos;

namespace WebHotel.Repository.UserProfileRepository
{
    public interface IUserRepository
    {
        Task<StatusDto> updateProfile(UserProfileRequestDto user);
        UserProfileResponseDto GetUserProfile(string email);
    }
}
