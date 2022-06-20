using System.ComponentModel.DataAnnotations;

namespace Planner.Entidades
{
    public class Anotacao
    {
        [Key]
        public int Id_Anotacao { get; set; }
        [Required]
        public int AulaId { get; set; }
        public virtual Aula Aula { get; set; }
        public string Titulo { get; set; }
        public string? Campo_Texto { get; set; }
        public string? Link { get; set; }

    }
}
