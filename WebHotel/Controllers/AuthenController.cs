﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebHotel.DTO;
using WebHotel.DTO.Authentication;
using WebHotel.Repository.AuthenRepository;
using WebHotel.Repository.EmailRepository;

namespace WebHotel.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenController : ControllerBase
    {
        private readonly IAuthenRepository _authenRepository;
        private readonly IMailRepository _mailRepository;

        public AuthenController(IAuthenRepository authenRepository, IMailRepository mailRepository)
        {
            _authenRepository = authenRepository;
            _mailRepository = mailRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            var result = await _authenRepository.Login(model);
            if (result is LoginResponseDto)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Registration([FromBody] RegistrationDto model)
        {
            StatusDto result = await _authenRepository.Registration(model);
            if (result.StatusCode == 1)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegistrationAdmin([FromBody] RegistrationDto model)
        {
            StatusDto result = await _authenRepository.RegistrationAdmin(model);
            if (result.StatusCode == 1)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<IActionResult> RequestResetPassword(string? email)
        {
            return Ok(await _authenRepository.RequestResetPassword(email));
        }

        [HttpPost]
        public IActionResult sendMail(EmailRequestDto emailRequest)
        {
            if (!_mailRepository.Email(emailRequest))
            {
                return BadRequest();
            }
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmailRegiste(string email, string code)
        {
            return Ok(await _authenRepository.ConfirmEmailRegiste(email, code));
        }

        [HttpPost]
        public async Task<IActionResult> RequestChangePassword(ForgotPasswordDto forgotPasswordModel)
        {
            return Ok(await _authenRepository.RequestChangePassword(forgotPasswordModel));
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmChangePassword(ResetPasswordDto resetPasswordModel)
        {
            return Ok(await _authenRepository.ConfirmChangePassword(resetPasswordModel));
        }
    }
}