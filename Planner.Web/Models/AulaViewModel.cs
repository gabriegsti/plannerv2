using System;
using System.ComponentModel.DataAnnotations;

namespace Planner.Web.Models
{
    public class AulaViewModel
    {
        [Key]
        [Required]
        public int Id_Aula { get; set; }
        [Required]
        public int Id_materia { get; set; }
        [Required(ErrorMessage = "O campo titulo é obrigatório.")]
        public string Titulo { get; set; }
        public DateTime Data_Hora { get; set; }
        public string Link { get; set; }
    }
}
