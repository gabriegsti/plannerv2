using Microsoft.AspNetCore.Mvc;
using Planner.Dados.Repositorios;
using Planner.Entidades;
using Planner.Web.Models;

namespace Planner.Web.Controllers
{
    public class AulaController : Controller
    {
        private readonly AulaRepositorio _repositorio;
        private readonly MateriaRepositorio RepositorioMateria;

        public AulaController(AulaRepositorio repositorio, MateriaRepositorio repositorioMateria)
        {
            _repositorio = repositorio;
            RepositorioMateria = repositorioMateria;

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
            List<MateriaViewModel> lst = new List<MateriaViewModel>();
            IEnumerable<Materia> materias = RepositorioMateria.Buscar();

            foreach (Materia materia in materias)
            {
                MateriaViewModel model = new MateriaViewModel();
                model.Id_Materia = materia.Id_Materia;
                model.Titulo = materia.Titulo;
                model.Data_Inicio = materia.Data_Inicio;
                model.Data_Fim = materia.Data_Fim;
                model.Professor = materia.Professor;
                model.Email = materia.Email;
                lst.Add(model);
            }
            ViewBag.Materias = lst;
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
            aula.Id_Materia = aulaViewModel.Id_Materia;

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

        public IActionResult Editar(int id)
        {
            var aula = _repositorio.Buscar(id);
            AulaViewModel model = new AulaViewModel();
            model.Titulo = aula.Titulo;
            model.Id_Materia = aula.Id_Materia;
            model.Id_Aula = aula.Id_Aula;
            model.Data_Hora = aula.Data_Hora;
            model.Link = aula.Link;
            var materia = RepositorioMateria.Buscar(aula.Id_Materia);
            if(materia != null)
                model.MateriaTitulo = materia.Titulo;
            return View(model);
        }

        public IActionResult EditarPorId(AulaViewModel aulaViewModel)
        {
            Aula aula = new Aula();
            aula.Id_Aula = aulaViewModel.Id_Aula;
            aula.Titulo = aulaViewModel.Titulo;
            aula.Id_Materia = aulaViewModel.Id_Materia;
            aula.Data_Hora = aulaViewModel.Data_Hora;
            aula.Link = aulaViewModel.Link;

            _repositorio.Atualizar(aula);
            return RedirectToAction("Index");
        }


    }
}
