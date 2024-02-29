using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestaoCinco.Application.DTOs
{
    public class ContaCorrenteCreateDTO
    {
        [Required(ErrorMessage = "O campo ContaId é obrigatorio.")]
        [DisplayName("Conta Numero")]
        public string ContaId { get; set; }

        [Required(ErrorMessage = "The Name is Required")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Nome Titular")]
        public string NomeTitular { get; set; }

        [Required(ErrorMessage = "Valor Inicial is Required")]
        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Valor Inicial")]
        [Range(0, double.MaxValue, ErrorMessage = "O Valor Inicial deve ser maior ou igual a 0.")]
        public decimal ValorInicial { get; set; }
    }
}
