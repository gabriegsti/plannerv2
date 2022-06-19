using System;
using System.ComponentModel.DataAnnotations;

namespace Planner.Entidades
{
    public class Aula
    {
        [Key]
        [Required]
        public int Id_Aula { get; set; }
        [Required]
        public int Id_Materia { get; set; }
        [Required(ErrorMessage = "O campo titulo é obrigatório.")]

        public List<Anotacao> LstAnotacoes { get; set; }
        public string Titulo { get; set; }
        public DateTime Data_Hora { get; set; }
        public string Link { get; set; }
    }
}
