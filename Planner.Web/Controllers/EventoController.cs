using Microsoft.AspNetCore.Mvc;
using Planner.Dados.Repositorios;
using Planner.Web.Models;

namespace Planner.Web.Controllers
{
    public class EventoController : Controller
    {
        private readonly EventoRepositorio _repositorio;

        public EventoController(EventoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public IActionResult Consulta()
        {
            List<EventoViewModel> lst = new List<EventoViewModel>();
            var eventos = _repositorio.Buscar();

            foreach (var evento in eventos)
            {
                EventoViewModel model = new EventoViewModel();
                model.Titulo = evento.Titulo;
                model.Data_Hora = evento.Data_Hora;
                model.Id_Evento = evento.Id_Evento;
                model.Id_Usuario = evento.Id_Usuario;
                model.Titulo = evento.Titulo.ToString();
                lst.Add(model);
            }

            return View(lst);
        }
    }
}
