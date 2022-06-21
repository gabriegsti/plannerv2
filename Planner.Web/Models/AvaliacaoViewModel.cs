
using Planner.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Planner.Web.Models
{
    public class AvaliacaoViewModel : IAgendavelViewModel
    {
        [Key]
        [Display(Name = "Cod.")]
        [Required]
        public int Id_Avaliacao { get; set; }
        
        [Required]
        public int Id_Materia { get; set; }

        [Display(Name = "Avaliação")]
        [Required(ErrorMessage ="Indentificação da Avaliação obrigatória")]
        public string Titulo { get; set; }
        
        public double? Nota { get; set; }
        
        [Display(Name = "Dia/Horário")]
        public DateTime? Data_Hora { get; set; }

        public int Id_Evento { get; set; }
    }
}
