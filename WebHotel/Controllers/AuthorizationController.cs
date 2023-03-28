using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebHotel.Model;
using WebHotel.Model.Authentication;
using WebHotel.Repository.AuthenRepository;
using WebHotel.Repository.EmailRepository;

namespace WebHotel.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthenRepository _authenRepository;
        private readonly IMailRepository _mailRepository;

        public AuthorizationController(IAuthenRepository authenRepository, IMailRepository mailRepository)
        {
            _authenRepository = authenRepository;
            _mailRepository = mailRepository;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var result = await _authenRepository.Login(model);
            if (result is LoginResponse)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Registration([FromBody] RegistrationModel model)
        {
            Status result = await _authenRepository.Registration(model);
            if (result.StatusCode == 1)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegistrationAdmin([FromBody] RegistrationModel model)
        {
            Status result = await _authenRepository.RegistrationAdmin(model);
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
        [AllowAnonymous]
        public IActionResult sendMail(EmailRequest emailRequest)
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
        public async Task<IActionResult> RequestChangePassword(ForgotPasswordModel forgotPasswordModel)
        {
            return Ok(await _authenRepository.RequestChangePassword(forgotPasswordModel));
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmChangePassword(ResetPasswordModel resetPasswordModel)
        {
            return Ok(await _authenRepository.ConfirmChangePassword(resetPasswordModel));
        }
    }
}
