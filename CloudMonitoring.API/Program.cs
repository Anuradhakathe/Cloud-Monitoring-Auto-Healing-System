using CloudMonitoring.API.Data;
using CloudMonitoring.API.Jobs;
using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --------------------
// SERVICES
// --------------------

// ✅ MVC + API
builder.Services.AddControllersWithViews();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext
builder.Services.AddDbContext<MonitoringDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

// Hangfire
builder.Services.AddHangfire(config =>
{
    config.UseMemoryStorage();
});
builder.Services.AddHangfireServer();

var app = builder.Build();

// --------------------
// SCHEDULE BACKGROUND JOB
// --------------------
using (var scope = app.Services.CreateScope())
{
    var recurringJobManager = scope.ServiceProvider
        .GetRequiredService<IRecurringJobManager>();

    recurringJobManager.AddOrUpdate<ServerMonitoringJob>(
        "server-health-job",
        job => job.CheckServerHealth(),
        Cron.Minutely
    );
}

// --------------------
// MIDDLEWARE
// --------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ✅ REQUIRED for MVC Views
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ✅ API Controllers
app.MapControllers();

// ✅ MVC Default Route (VERY IMPORTANT)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
