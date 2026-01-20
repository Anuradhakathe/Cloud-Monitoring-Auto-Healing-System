using Microsoft.AspNetCore.Mvc;
using CloudMonitoring.API.Data;
using CloudMonitoring.API.Models;

namespace CloudMonitoring.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServerController : ControllerBase
    {
        private readonly MonitoringDbContext _dbContext;

        public ServerController(MonitoringDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Live status
        [HttpGet("status")]
        public IActionResult GetServerStatus()
        {
            var status = new ServerStatus
            {
                ServerName = "Server-01",
                CpuUsage = Random.Shared.Next(10, 90),
                MemoryUsage = Random.Shared.Next(20, 95),
                Status = "Running",
                CheckedAt = DateTime.Now
            };

            return Ok(status);
        }

        // History from DB
        [HttpGet("history")]
        public IActionResult GetServerHistory()
        {
            var history = _dbContext.ServerStatusLogs
                .OrderByDescending(x => x.CheckedAt)
                .Take(20)
                .ToList();

            return Ok(history);
        }
    }
}
