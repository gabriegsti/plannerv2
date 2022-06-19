using Microsoft.AspNetCore.Mvc;

namespace Planner.Web.Controllers
{
    public class AulaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
