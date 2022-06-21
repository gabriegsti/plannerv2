using Microsoft.AspNetCore.Mvc;
using Planner.Dados.Repositorios;
using Planner.Entidades;
using Planner.Web.Models;

namespace Planner.Web.Controllers
{
    public class AnotacaoController : Controller
    {
        private readonly AnotacaoRepositorio _repositorio;

        public AnotacaoController(AnotacaoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Index()
        {
            List<AnotacaoViewModel> lst = new List<AnotacaoViewModel>();
            var anotacoes = _repositorio.Buscar();

            foreach (var anotacao in anotacoes)
            {
                AnotacaoViewModel model = new AnotacaoViewModel();
                model.Id_Anotacao = anotacao.Id_Anotacao;
                model.Titulo = anotacao.Titulo;
                model.Campo_Texto = anotacao.Campo_Texto;
                model.Link = anotacao.Link;
                model.Titulo = anotacao.Titulo.ToString();
                lst.Add(model);
            }

            return View(lst);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastrar(AnotacaoViewModel anotacaoViewModel)
        {
            Anotacao anotacao = new Anotacao();
            anotacao.Titulo = anotacaoViewModel.Titulo;
            anotacao.Campo_Texto = anotacaoViewModel.Campo_Texto;
            anotacao.Id_Anotacao = anotacaoViewModel.Id_Anotacao;
            anotacao.Link = anotacaoViewModel.Link;
            anotacao.Titulo = anotacaoViewModel.Titulo.ToString();

            var id = _repositorio.Adicionar(anotacao);

            return RedirectToAction("Index");
        }


        public IActionResult Remover(int id)
        {
            var anotacao = _repositorio.Buscar(id);

            AnotacaoViewModel model = new AnotacaoViewModel();
            model.Id_Anotacao = anotacao.Id_Anotacao;
            model.Titulo = anotacao.Titulo;
            model.Campo_Texto = anotacao.Campo_Texto;
            model.Link = anotacao.Link;
            model.Titulo = anotacao.Titulo.ToString();

            return View(model);
        }

        public IActionResult RemoverPorId(int id)
        {
            _repositorio.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}
