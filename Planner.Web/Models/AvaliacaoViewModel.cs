
using Microsoft.AspNetCore.Mvc.Rendering;
using Planner.Dados.Repositorios;
using Planner.Entidades;
using Planner.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Planner.Web.Models
{
    public class AvaliacaoViewModel : IAgendavelViewModel
    {    

        [Key]
        [Display(Name = "Cod.")]
        public int Id_Avaliacao { get; set; }
        [Display(Name = "Matéria")]
        public int Id_Materia { get; set; }

        [Display(Name = "Avaliação")]
        [Required(ErrorMessage ="Indentificação da Avaliação obrigatória")]
        public string Titulo { get; set; }
        
        public double? Nota { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Display(Name = "Dia/Horário")]
        public DateTime? Data_Hora { get; set; }

        public int Id_Evento { get; set; }

        [Display(Name = "Matéria")]
        public string materia { get; set; }
    }
}
