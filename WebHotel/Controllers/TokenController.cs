using Microsoft.AspNetCore.Mvc;
using WebHotel.Model;
using WebHotel.Model.Token;
using WebHotel.Repository.TokenRepository;

namespace WebHotel.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly ITokenRepository _service;

        public TokenController(ITokenRepository service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult Refresh(TokenRequest tokenRequest)
        {
            var token = _service.RefreshToken(tokenRequest);
            if (token is Status)
            {
                return BadRequest(token);
            }
            return Ok(token);
        }

        [HttpPost]
        public IActionResult Revoke(TokenRequest tokenRequest)
        {
            bool check = _service.Revoke(tokenRequest);
            if (!check)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
