using System;

namespace Planner.Interfaces
{
    public interface IAgendavelViewModel
    {
        public string Titulo { get; set; }
        public DateTime? Data_Hora { get; set; }
    }
}
