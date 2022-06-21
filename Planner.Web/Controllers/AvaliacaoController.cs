using Microsoft.AspNetCore.Mvc;
using Planner.Dados.Repositorios;
using Planner.Entidades;
using Planner.Web.Models;

namespace Planner.Web.Controllers
{
    public class AvaliacaoController : Controller
    {
        private readonly AvaliacaoRepositorio _repositorio;

        public AvaliacaoController(AvaliacaoRepositorio repositorio)
        {
            _repositorio = repositorio;
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

        public IActionResult Cadastrar()
        {
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
            avaliacao.Titulo = aulaViewModel.Titulo.ToString();

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
    }
}
