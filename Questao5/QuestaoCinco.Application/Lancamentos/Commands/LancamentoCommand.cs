using QuestaoCinco.Domain.Entities;
using MediatR;
using System.Text.Json.Serialization;

namespace QuestaoCinco.Application.Lancamentos.Commands
{
    public abstract class LancamentoCommand : IRequest<Lancamento>
    {
        //public int LancamentoId { get; set; }

        public string DebitoCredito { get; set; }

        public decimal Valor { get; set; }

        public string ContaId { get; set; }

        public decimal SaldoAntes { get; set; }

        public decimal SaldoApos { get; set; }
    }
}
