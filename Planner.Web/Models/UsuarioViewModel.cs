using System.ComponentModel.DataAnnotations;

namespace Planner.Web.Models
{
    public class UsuarioViewModel
    {
        [Key]
        [Required]
        public int Id_Usuario { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "O campo email deve ter entre 8 e 100 caracateres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "O campo senha deve ter entre 8 e 100 caracateres.")]
        public string Senha { get; set; }
    }
}
