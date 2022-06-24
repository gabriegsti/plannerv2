using Microsoft.AspNetCore.Mvc;
using Planner.Dados.Repositorios;
using Planner.Entidades;
using Planner.Web.Models;

namespace Planner.Web.Controllers
{
    public class MateriaController : Controller
    {
        private MateriaRepositorio Repositorio { get; }

        public MateriaController(MateriaRepositorio repositorio)
        {
            Repositorio = repositorio;
        }
        public IActionResult Index()
        {
            List<MateriaViewModel> lst = new List<MateriaViewModel>();
            var materias = Repositorio.Buscar();

            foreach (var materia in materias)
            {
                MateriaViewModel model = new MateriaViewModel();
                model.Id_Materia = materia.Id_Materia;
                model.Id_Usuario = materia.Id_Usuario;
                model.Titulo = materia.Titulo;
                model.Email = materia.Email;
                model.Professor = materia.Professor;
                model.Data_Inicio = materia.Data_Inicio;
                model.Data_Fim = materia.Data_Fim;
                lst.Add(model);
            }
            return View(lst);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(MateriaViewModel materiaViewModel)
        {
            Materia materia = new Materia();
            materia.Id_Usuario = materiaViewModel.Id_Usuario;
            materia.Titulo = materiaViewModel.Titulo;
            materia.Email = materiaViewModel.Email;
            materia.Professor = materiaViewModel.Professor;
            materia.Data_Inicio = materiaViewModel.Data_Inicio;
            materia.Data_Fim = materiaViewModel.Data_Fim;

            Repositorio.Adicionar(materia);

            return RedirectToAction("Index");
        }

        public IActionResult Remover(int id)
        {
            var materia = Repositorio.Buscar(id);

            MateriaViewModel model = new MateriaViewModel();
            model.Id_Materia = materia.Id_Materia;
            model.Id_Usuario = materia.Id_Usuario;
            model.Titulo = materia.Titulo;
            model.Email = materia.Email;
            model.Professor = materia.Professor;
            model.Data_Inicio = materia.Data_Inicio;
            model.Data_Fim = materia.Data_Fim;

            return View(model);
        }

        public IActionResult RemoverPorId(int id)
        {
            Repositorio.Excluir(id);
            return RedirectToAction("Index");
        }


        public IActionResult Editar(int id)
        {
            var materia = Repositorio.Buscar(id);

            MateriaViewModel model = new MateriaViewModel();
            model.Id_Materia = materia.Id_Materia;
            model.Id_Usuario = materia?.Id_Usuario;
            model.Titulo = materia?.Titulo;
            model.Email = materia?.Email;
            model.Professor = materia?.Professor;
            model.Data_Inicio = materia?.Data_Inicio;
            model.Data_Fim = materia?.Data_Fim;


            return View(model);
        }

        public IActionResult EditarPorId(MateriaViewModel materiaViewModel)
        {
            Materia materia = new Materia();
            materia.Id_Materia = materiaViewModel.Id_Materia;
            materia.Id_Usuario = materiaViewModel.Id_Usuario;
            materia.Titulo = materiaViewModel.Titulo;
            materia.Email = materiaViewModel.Email;
            materia.Professor = materiaViewModel.Professor;
            materia.Data_Inicio = materiaViewModel.Data_Inicio;
            materia.Data_Fim = materiaViewModel.Data_Fim;
            Repositorio.Atualizar(materia);

            return RedirectToAction("Index");
        }


    }
}
