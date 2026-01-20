using Microsoft.AspNetCore.Mvc;
using CloudMonitoring.API.Data;

namespace CloudMonitoring.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncidentController : ControllerBase
    {
        private readonly MonitoringDbContext _dbContext;

        public IncidentController(MonitoringDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetIncidents()
        {
            var incidents = _dbContext.Incidents
                .OrderByDescending(i => i.CreatedAt)
                .ToList();

            return Ok(incidents);
        }
    }
}
