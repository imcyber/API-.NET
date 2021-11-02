using System;
using System.ComponentModel.DataAnnotations;

namespace api.domain.Dtos.User
{
    public class UserDtoUpdate
    {

        [Required(ErrorMessage = "Campo Id é obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatório")]
        [StringLength(60, ErrorMessage = "Tamanho máximo permitido no campo nome é {1} caracteres")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo email é obrigatório")]
        [StringLength(100, ErrorMessage = "Tamanho máximo permitido no campo email é {1} caracteres")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; }
    }
}
