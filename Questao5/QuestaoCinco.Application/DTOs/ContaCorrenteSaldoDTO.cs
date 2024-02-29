using QuestaoCinco.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuestaoCinco.Application.DTOs
{
    public class ContaCorrenteSaldoDTO : ContaCorrenteDTO
    {
        //[Required(ErrorMessage = "O campo ContaId é obrigatorio.")]
        //[DisplayName("Conta Numero")]
        //public string ContaId { get; set; }

        //[Required(ErrorMessage = "The Name is Required")]
        //[MinLength(3)]
        //[MaxLength(100)]
        //[DisplayName("Nome Titular")]
        //public string NomeTitular { get; set; }

        //[Required(ErrorMessage = "Valor Inicial is Required")]
        //[Column(TypeName = "decimal(18,2)")]
        //[DisplayFormat(DataFormatString = "{0:C2}")]
        //[DataType(DataType.Currency)]
        //[DisplayName("Valor Inicial")]
        //public decimal ValorInicial { get; set; }

        //[Column(TypeName = "decimal(18,2)")]
        //[DisplayFormat(DataFormatString = "{0:C2}")]
        //[DataType(DataType.Currency)]
        //[DisplayName("SaldoAtual")]
        public decimal SaldoAtual { get; set; }

    }
}
