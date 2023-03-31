using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebHotel.DTO.UserDtos;
using WebHotel.Repository.UserProfileRepository;

namespace WebHotel.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    //[HttpPost]
    //[AllowAnonymous]
    //public async Task<IActionResult> SendFile(string urlFile, IFormFile formFile)
    //{
    //    FileService a = new FileService();
    //    await a.SendFile(urlFile, formFile);
    //    return Ok();
    //}

    //[HttpGet]
    //[AllowAnonymous]
    //public async Task<IActionResult> deleteFile(string urlFile)
    //{
    //    FileService a = new FileService();
    //    await a.deleteFile(urlFile);
    //    return Ok();
    //}

    //[HttpGet]
    //[AllowAnonymous]
    //public async Task<IActionResult> GetFile(string fileName)
    //{
    //    FileService a = new FileService();
    //    var response = await a.GetFile(fileName);
    //    return Ok(response);
    //}

    [HttpPost]
    public async Task<IActionResult> UpdateProfile([FromForm] UserProfileRequestDto _user)
    {
        if (ModelState.IsValid)
        {
            var emailLogin = User.FindFirst(ClaimTypes.Email)!.Value;
            if (emailLogin == _user.Email)
            {
                var status = await _userRepository.updateProfile(_user);
                if (status.StatusCode == 1)
                {
                    return Ok(status);
                }
                else
                {
                    return BadRequest(status);
                }
            }
        }
        return BadRequest();
    }

    [HttpGet]
    public IActionResult GetUserProfile()
    {
        var email = User.FindFirst(ClaimTypes.Email)!.Value;
        var result = _userRepository.GetUserProfile(email);
        if (result is null)
        {
            return NotFound();
        }
        return Ok(result);
    }
}