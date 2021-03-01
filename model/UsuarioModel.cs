using System;
using System.ComponentModel.DataAnnotations;

namespace itbit_asp_net_core.Model
{
    public class UsuarioModel
    {
        [Key]
        public Guid Id { get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter no minimo {2} caracters", MinimumLength = 3)]
        public string Nome {get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataNascimento {get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Sexo {get; set;}

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email {get; set;}

        public string Senha {get; set;}

        public bool Ativo {get; set;}
    }
}