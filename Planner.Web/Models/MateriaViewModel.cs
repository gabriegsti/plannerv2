using System;
using System.ComponentModel.DataAnnotations;

namespace Planner.Web.Models
{
    public class MateriaViewModel
    {
        [Key]
        public int Id_Materia { get; set; }
        [Required(ErrorMessage = "O campo id_usuario é obrigatório.")]
        public int? Id_Usuario { get; set; }

        [Display(Name = "Matéria")]
        public string Titulo { get; set; }

        [Display(Name = "E-mail")]
        public string? Email { get; set; }
        public string? Professor { get; set; }

        [Display(Name = "Início")]
        public DateTime? Data_Inicio { get; set; }

        [Display(Name = "Fim")]
        public DateTime? Data_Fim { get; set; }
        public List<AvaliacaoViewModel>? LstAvaliacoes { get; set; }
        public List<AulaViewModel>? LstAulas { get; set; }
    }
}
