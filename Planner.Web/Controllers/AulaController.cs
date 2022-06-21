using Microsoft.AspNetCore.Mvc;
using Planner.Dados.Repositorios;
using Planner.Entidades;
using Planner.Web.Models;

namespace Planner.Web.Controllers
{
    public class AulaController : Controller
    {
        private readonly AulaRepositorio _repositorio;

        public AulaController(AulaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            List<AulaViewModel> lst = new List<AulaViewModel>();
            var aulas = _repositorio.Buscar();

            foreach (var aula in aulas)
            {
                AulaViewModel model = new AulaViewModel();
                model.Id_Aula = aula.Id_Aula;
                model.Titulo = aula.Titulo;
                model.Data_Hora = aula.Data_Hora;
                model.Link = aula.Link;
                model.Titulo = aula.Titulo.ToString();
                lst.Add(model);
            }

            return View(lst);
        }
                
        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(AulaViewModel aulaViewModel)
        {
            Aula aula = new Aula();
            aula.Titulo = aulaViewModel.Titulo;
            aula.Data_Hora = aulaViewModel.Data_Hora;
            aula.Id_Aula = aulaViewModel.Id_Aula;
            aula.Link = aulaViewModel.Link;
            aula.Titulo = aulaViewModel.Titulo.ToString();

            var id = _repositorio.Adicionar(aula);

            return RedirectToAction("Index");
        }


        public IActionResult Remover(int id)
        {
            var aula = _repositorio.Buscar(id);

            AulaViewModel model = new AulaViewModel();
            model.Id_Aula = aula.Id_Aula;
            model.Titulo = aula.Titulo;
            model.Data_Hora = aula.Data_Hora;
            model.Link = aula.Link;
            model.Titulo = aula.Titulo.ToString();
            
            return View(model);
        }

        public IActionResult RemoverPorId(int id)
        {
            _repositorio.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
