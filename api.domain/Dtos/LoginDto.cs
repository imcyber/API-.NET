using System.ComponentModel.DataAnnotations;

namespace api.domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email é obrigatório!")]
        [EmailAddress(ErrorMessage = "Email em formato inválido!")]
        [StringLength(100, ErrorMessage = ("Email deve ter no máximo {1} caracteres"))]
        public string Email { get; set; }
    }
}
