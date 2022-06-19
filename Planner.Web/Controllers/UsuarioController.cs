using Microsoft.AspNetCore.Mvc;

namespace Planner.Web.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
