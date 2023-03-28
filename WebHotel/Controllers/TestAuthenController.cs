using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebHotel.Repository.NotifiHub;

namespace WebHotel.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TestAuthenController : ControllerBase
    {
        public TestAuthenController()
        {
            
        }

        [HttpGet]
        public IActionResult getData()
        {
            string s = "Đã get thành công";
            return Ok(s);
        }
    }
}
