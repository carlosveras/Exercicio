using System;
using System.Collections.Generic;
using System.Drawing;

namespace QuestaoCinco.Domain.Entities
{
    public class ContaCorrente
    {
        public ContaCorrente()
        {
            Lancamentos = new List<Lancamento>();
        }

        public ContaCorrente(string contaId, string nomeTitular, decimal? valorInicial)
        {
            ContaId = contaId;
            NomeTitular = nomeTitular;
            ValorInicial = valorInicial;
        }

        public string ContaId { get; set; }
        public string NomeTitular { get; set; }

        public decimal? ValorInicial { get; set; }

        public decimal? SaldoAtual { get; set; }

        public List<Lancamento> Lancamentos { get; set; }

        public void Update(string nomeTitular)
        {
            NomeTitular = nomeTitular;
        }

        public void UpdateSaldoAtual(decimal? valor)
        {
            SaldoAtual = valor.Value;
        }

    }
}
