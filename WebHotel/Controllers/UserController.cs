using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebHotel.DTO.UserDtos;
using WebHotel.Repository.UserProfileRepository;
using WebHotel.Service.FileService;

namespace WebHotel.Controllers;

[ApiController]
[Authorize(Roles = "User")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost]
    [AllowAnonymous]
    [Route("/user/send-file")]
    public async Task<IActionResult> SendFile(string urlFile, IFormFile formFile)
    {
        FileService a = new FileService();
        await a.SendFile(urlFile, formFile);
        return Ok();
    }

    [HttpGet]
    [AllowAnonymous]
    [Route("/user/delete-file")]
    public async Task<IActionResult> deleteFile(string urlFile)
    {
        FileService a = new FileService();
        await a.deleteFile(urlFile);
        return Ok();
    }

    [HttpGet]
    [AllowAnonymous]
    [Route("/user/get-file")]
    public async Task<IActionResult> GetFile(string fileName)
    {
        FileService a = new FileService();
        var response = await a.GetFile(fileName);
        return Ok(response);
    }

    [HttpPost]
    [Route("/user/user-profile/update")]
    public async Task<IActionResult> Update([FromForm] UserProfileRequestDto _user)
    {
        var emailLogin = User.FindFirst(ClaimTypes.Email)!.Value;

        var status = await _userRepository.Update(_user, emailLogin);
        if (status.StatusCode == 1)
        {
            return Ok(status);
        }
        else
        {
            return BadRequest(status);
        }
    }

    [HttpGet]
    [Route("/user/user-profile/get")]
    public IActionResult Get()
    {
        var email = User.FindFirst(ClaimTypes.Email)!.Value;
        var result = _userRepository.Get(email);
        if (result is null)
        {
            return NotFound();
        }
        return Ok(result);
    }
}