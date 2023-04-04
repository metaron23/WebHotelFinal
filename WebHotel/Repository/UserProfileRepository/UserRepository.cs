using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;
using WebHotel.Data;
using WebHotel.DTO;
using WebHotel.DTO.UserDtos;
using WebHotel.Model;
using WebHotel.Service.FileService;

namespace WebHotel.Repository.UserProfileRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDBContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public UserRepository(MyDBContext context, UserManager<ApplicationUser> userManager, IMapper mapper, IFileService fileService)
        {
            _context = context;
            _userManager = userManager;
            _mapper = mapper;
            _fileService = fileService;
        }

        [return: MaybeNull]
        public UserProfileResponseDto GetUserProfile(string email)
        {
            var user = _context.ApplicationUsers.SingleOrDefault(a => a.Email == email);
            if (user is not null)
            {
                var userResponse = new UserProfileResponseDto();
                _mapper.Map(user, userResponse);
                return userResponse;
            }
            return default;
        }

        public async Task<StatusDto> updateProfile(UserProfileRequestDto _user)
        {
            var user = _context.ApplicationUsers.SingleOrDefault(a => a.Email == _user.Email);
            if (user is not null)
            {
                user = _mapper.Map(_user, user);
                if (_user.Image is not null)
                {
                    var checkSendFile = await _fileService.SendFile("ProfileUser/" + user.Email, _user.Image!);
                    if (checkSendFile)
                    {
                        user.Image = await _fileService.GetFile("ProfileUser/" + user.Email + "/" + _user.Image!.FileName);
                    }
                    else
                    {
                        return new StatusDto { StatusCode = 0, Message = "Save image failed!" };
                    }
                }
                try
                {
                    _context.ApplicationUsers.Update(user);
                    await _context.SaveChangesAsync();
                    return new StatusDto { StatusCode = 1, Message = "Profile update successfull" };

                }
                catch
                {
                    return new StatusDto { StatusCode = 0, Message = "Error Update!" };
                }
            }
            return new StatusDto { StatusCode = 0, Message = "Email not found" };
        }
    }
}
