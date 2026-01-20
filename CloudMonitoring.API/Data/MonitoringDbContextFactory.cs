using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CloudMonitoring.API.Data
{
    public class MonitoringDbContextFactory
        : IDesignTimeDbContextFactory<MonitoringDbContext>
    {
        public MonitoringDbContext CreateDbContext(string[] args)
        {
            // Build configuration
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Create options builder
            var optionsBuilder = new DbContextOptionsBuilder<MonitoringDbContext>();

            optionsBuilder.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection"));

            return new MonitoringDbContext(optionsBuilder.Options);
        }
    }
}
