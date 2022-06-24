using System;
using System.ComponentModel.DataAnnotations;

namespace Planner.Web.Models
{
    public class AulaViewModel
    {
        [Key]
        [Required]
        public int Id_Aula { get; set; }
        [Display(Name = "Matéria")]
        public int Id_Materia { get; set; }

        [Required(ErrorMessage = "O campo titulo é obrigatório.")]
        public string Titulo { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true)]
        [Display(Name = "Dia/Horário")]
        public DateTime Data_Hora { get; set; }
        public string Link { get; set; }
        [Display(Name = "Matéria")]
        public string MateriaTitulo { get; set; }
    }
}
