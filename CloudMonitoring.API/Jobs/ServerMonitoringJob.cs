using CloudMonitoring.API.Data;
using CloudMonitoring.API.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CloudMonitoring.API.Jobs
{
    public class ServerMonitoringJob
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<ServerMonitoringJob> _logger;

        public ServerMonitoringJob(
            IServiceScopeFactory scopeFactory,
            ILogger<ServerMonitoringJob> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public void CheckServerHealth()
        {
            using var scope = _scopeFactory.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<MonitoringDbContext>();

            var cpu = Random.Shared.Next(10, 100);
            var memory = Random.Shared.Next(20, 100);

            var statusLog = new ServerStatusLog
            {
                ServerName = "Server-01",
                CpuUsage = cpu,
                MemoryUsage = memory,
                CheckedAt = DateTime.Now,
                Status = (cpu > 85 || memory > 90) ? "Critical" : "Running"
            };

            dbContext.ServerStatusLogs.Add(statusLog);

            // 🔥 INCIDENT + ALERT LOGIC
            if (cpu > 85 || memory > 90)
            {
                var incident = new Incident
                {
                    ServerName = "Server-01",
                    Issue = $"High resource usage (CPU: {cpu}%, MEM: {memory}%)",
                    Severity = "Critical",
                    CreatedAt = DateTime.Now,
                    IsResolved = false
                };

                dbContext.Incidents.Add(incident);

                var alert = new Alert
                {
                    ServerName = "Server-01",
                    Message = $"ALERT: Critical usage detected! CPU {cpu}% MEM {memory}%",
                    AlertType = "Email",
                    CreatedAt = DateTime.Now
                };

                dbContext.Alerts.Add(alert);

                _logger.LogError(
                    "EMAIL ALERT SENT → {Server} | CPU {Cpu}% | MEM {Mem}%",
                    "Server-01", cpu, memory
                );
            }

            dbContext.SaveChanges();

            _logger.LogInformation(
                "MONITOR → {Server} | CPU {Cpu}% | MEM {Mem}% | STATUS {Status}",
                "Server-01", cpu, memory, statusLog.Status
            );
        }
    }
}
