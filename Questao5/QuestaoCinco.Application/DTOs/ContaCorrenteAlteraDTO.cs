using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace QuestaoCinco.Application.DTOs
{
    public class ContaCorrenteAlteraDTO
    {
        [Required(ErrorMessage = "O campo ContaId é obrigatorio.")]
        [DisplayName("Conta Numero")]
        public string ContaId { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome Titular")]
        public string NomeTitular { get; set; }
    }
}
