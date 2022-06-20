using System.ComponentModel.DataAnnotations;

namespace Planner.Entidades
{
    public class Usuario
    {
        [Key]
        public int Id_Usuario { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Senha { get; set; }
    }
}
