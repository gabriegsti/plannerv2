using Microsoft.AspNetCore.Mvc;
using Planner.Dados.Repositorios;
using Planner.Web.Models;
using System.Diagnostics;

namespace Planner.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AnotacaoRepositorio _repositorio;

        public HomeController(ILogger<HomeController> logger, AnotacaoRepositorio repositorio)
        {
            _logger = logger;
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}