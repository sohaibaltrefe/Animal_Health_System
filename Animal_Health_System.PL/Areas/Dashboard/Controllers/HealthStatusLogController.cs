using Microsoft.AspNetCore.Mvc;

namespace Animal_Health_System.PL.Areas.Dashboard.Controllers
{
    public class HealthStatusLogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
