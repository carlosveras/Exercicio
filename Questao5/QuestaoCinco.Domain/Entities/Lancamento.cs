using System;

namespace QuestaoCinco.Domain.Entities
{
    public class Lancamento
    {

        public Lancamento()
        {

        }

        public Lancamento(string debitoCredito, decimal valor, string contaId, decimal saldoAntes, decimal saldoApos)
        {
            DebitoCredito = debitoCredito;
            Valor = valor;
            ContaId = contaId;
            SaldoAntes = saldoAntes;
            SaldoApos = saldoApos;
        }

        public int LancamentoId { get; set; }

        public string DebitoCredito { get; set; }

        public decimal Valor { get; set; }

        public decimal SaldoAntes { get; set; }

        public decimal SaldoApos { get; set; }

        public DateTime DataTransacao { get; set; } = DateTime.Now;

        public string ContaId { get; set; }

        public void SaldoAntesTransacao(decimal? valor)
        {
            this.SaldoAntes = valor.Value;
        }

        public void SaldoAposTransacao (decimal? valor)
        {
            this.SaldoApos = valor.Value;
        }

    }
}
