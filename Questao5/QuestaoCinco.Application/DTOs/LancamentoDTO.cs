using QuestaoCinco.Domain.Entities;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestaoCinco.Application.DTOs
{
    public class LancamentoDTO
    {
        public int LancamentoId { get; set; }

        [Required(ErrorMessage = "Debito ou Credito is Required")]
        [MinLength(1)]
        [MaxLength(1)]
        [DisplayName("Debito ou Credito")]
        [RegularExpression("^[DC]$", ErrorMessage = "O campo DebitoCredito só aceita D ou C")]
        public string DebitoCredito { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Valor")]
        [Range(1, double.MaxValue, ErrorMessage = "O Valor Inicial deve ser maior que a 0.")]
        [Required(ErrorMessage = "Valor is Required")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "ContaId is Required")]
        [DisplayName("Conta Id")]
        public string ContaId { get; set; }
    }
}
