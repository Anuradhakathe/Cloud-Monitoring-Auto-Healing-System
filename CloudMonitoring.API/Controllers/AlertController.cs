using Microsoft.AspNetCore.Mvc;
using CloudMonitoring.API.Data;

namespace CloudMonitoring.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlertController : ControllerBase
    {
        private readonly MonitoringDbContext _dbContext;

        public AlertController(MonitoringDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAlerts()
        {
            var alerts = _dbContext.Alerts
                .OrderByDescending(a => a.CreatedAt)
                .ToList();

            return Ok(alerts);
        }
    }
}
