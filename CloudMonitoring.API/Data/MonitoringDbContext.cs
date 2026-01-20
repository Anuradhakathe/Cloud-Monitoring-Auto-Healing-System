using Microsoft.EntityFrameworkCore;
using CloudMonitoring.API.Models;

namespace CloudMonitoring.API.Data
{
    public class MonitoringDbContext : DbContext
    {
        public MonitoringDbContext(DbContextOptions<MonitoringDbContext> options)
            : base(options)
        {
        }

        public DbSet<ServerStatusLog> ServerStatusLogs { get; set; }
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Alert> Alerts { get; set; }   // 🔥 NEW
    }
}
