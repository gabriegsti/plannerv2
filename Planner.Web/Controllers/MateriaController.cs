using Microsoft.AspNetCore.Mvc;

namespace Planner.Web.Controllers
{
    public class MateriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
