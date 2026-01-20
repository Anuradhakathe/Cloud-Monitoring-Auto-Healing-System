using Microsoft.AspNetCore.Mvc;

namespace CloudMonitoring.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHealth()
        {
            var response = new
            {
                Status = "OK",
                Message = "System is running fine",
                ServerTime = DateTime.Now
            };

            return Ok(response);
        }
    }
}
