using System;

namespace Planner.Interfaces
{
    public interface IAgendavel
    {
        public string Titulo { get; set; }
        public DateTime? Data_Hora { get; set; }
    }
}
