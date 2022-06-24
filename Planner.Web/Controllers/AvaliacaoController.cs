using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Planner.Dados.Repositorios;
using Planner.Entidades;
using Planner.Web.Models;
using System.Collections.Generic;

namespace Planner.Web.Controllers
{
    public class AvaliacaoController : Controller
    {
        private readonly AvaliacaoRepositorio _repositorio;

        private readonly MateriaRepositorio _repositorioMateria;

        public AvaliacaoController(AvaliacaoRepositorio repositorio, MateriaRepositorio repositorioMateria)
        {
            _repositorio = repositorio;
            _repositorioMateria = repositorioMateria;
        }

        public IActionResult Index()
        {
            List<AvaliacaoViewModel> lst = new List<AvaliacaoViewModel>();
            var avaliacoes = _repositorio.Buscar();

            foreach (var avaliacao in avaliacoes)
            {
                AvaliacaoViewModel model = new AvaliacaoViewModel();
                model.Id_Avaliacao = avaliacao.Id_Avaliacao;
                model.Titulo = avaliacao.Titulo;
                model.Data_Hora = avaliacao.Data_Hora;
                model.Nota = avaliacao.Nota;
                model.Titulo = avaliacao.Titulo.ToString();
                lst.Add(model);
            }

            return View(lst);
        }

        public IActionResult Nota()
        {
            List<AvaliacaoViewModel> lst = new List<AvaliacaoViewModel>();
            var avaliacoes = _repositorio.Buscar();

            foreach (var avaliacao in avaliacoes)
            {
                AvaliacaoViewModel model = new AvaliacaoViewModel();
                model.Id_Avaliacao = avaliacao.Id_Avaliacao;
                model.Titulo = avaliacao.Titulo;
                model.Data_Hora = avaliacao.Data_Hora;
                model.Nota = avaliacao.Nota;
                model.Titulo = avaliacao.Titulo.ToString();
                lst.Add(model);
            }

            return View(lst);
        }

        public IActionResult Cadastrar()
        {
            List<MateriaViewModel> lst = new List<MateriaViewModel>();
           IEnumerable<Materia> materias = _repositorioMateria.Buscar();

            foreach (Materia materia in materias)
            {
                MateriaViewModel model = new MateriaViewModel();
                model.Id_Materia = materia.Id_Materia;
                model.Titulo = materia.Titulo ;
                model.Data_Inicio = materia.Data_Inicio;
                model.Data_Fim = materia.Data_Fim ;
                model.Professor = materia.Professor ;
                model.Email = materia.Email ;  
                lst.Add(model);
            }
            ViewBag.Materias = lst;
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(AvaliacaoViewModel aulaViewModel)
        {
            Avaliacao avaliacao = new Avaliacao();
            avaliacao.Titulo = aulaViewModel.Titulo;
            avaliacao.Data_Hora = aulaViewModel.Data_Hora;
            avaliacao.Id_Avaliacao = aulaViewModel.Id_Avaliacao;
            avaliacao.Nota = aulaViewModel.Nota;
            avaliacao.MateriaId = aulaViewModel.Id_Materia;

            var id = _repositorio.Adicionar(avaliacao);

            return RedirectToAction("Index");
        }


        public IActionResult Remover(int id)
        {
            var avaliacao = _repositorio.Buscar(id);

            AvaliacaoViewModel model = new AvaliacaoViewModel();
            model.Id_Avaliacao = avaliacao.Id_Avaliacao;
            model.Titulo = avaliacao.Titulo;
            model.Data_Hora = avaliacao.Data_Hora;
            model.Nota = avaliacao.Nota;
            model.Titulo = avaliacao.Titulo.ToString();

            return View(model);
        }

        public IActionResult RemoverPorId(int id)
        {
            _repositorio.Excluir(id);
            return RedirectToAction("Index");
        }

        public IActionResult Editar(int id)
        {
            var avaliacao = _repositorio.Buscar(id);
            var materia = _repositorioMateria.Buscar(avaliacao.MateriaId);
           
            AvaliacaoViewModel model = new AvaliacaoViewModel();
            model.Id_Avaliacao = avaliacao.Id_Avaliacao;
            model.Titulo = avaliacao.Titulo;
            model.Nota = avaliacao.Nota;
            model.Data_Hora = avaliacao.Data_Hora;
            model.Id_Materia = avaliacao.MateriaId;
            model.Id_Evento = avaliacao.EventoId;
            model.materia = materia.Titulo;

            return View(model); 
        }

        public IActionResult EditarPorId(AvaliacaoViewModel avaliacaoViewModel)
        {
            Avaliacao avaliacao = new Avaliacao();
            avaliacao.Id_Avaliacao = avaliacaoViewModel.Id_Avaliacao;
            avaliacao.Titulo = avaliacaoViewModel.Titulo;
            avaliacao.Nota = avaliacaoViewModel.Nota;
            avaliacao.Data_Hora = avaliacaoViewModel.Data_Hora;
            avaliacao.MateriaId = avaliacaoViewModel.Id_Materia;
            avaliacao.EventoId = avaliacaoViewModel.Id_Materia;
            _repositorio.Atualizar(avaliacao);

            return RedirectToAction("Index");
        }
    }
}
