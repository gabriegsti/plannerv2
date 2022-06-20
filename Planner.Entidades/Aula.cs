using System;
using System.ComponentModel.DataAnnotations;

namespace Planner.Entidades
{
    public class Aula
    {
        [Key]
        public int Id_Aula { get; set; }
        public int Id_Materia { get; set; }
        public List<Anotacao> LstAnotacoes { get; set; }
        [MaxLength(100)]
        public string Titulo { get; set; }
        public DateTime Data_Hora { get; set; }
        [MaxLength(100)]
        public string Link { get; set; }
    }
}
