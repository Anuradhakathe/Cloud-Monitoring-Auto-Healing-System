using Microsoft.AspNetCore.Mvc;

namespace CloudMonitoring.API.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
