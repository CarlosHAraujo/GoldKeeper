using Microsoft.AspNetCore.Mvc;

namespace GoldKeeper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        public IActionResult Get()
        {
            return Ok("Hello World!");
        }
    }
}
