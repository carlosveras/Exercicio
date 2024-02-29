using QuestaoCinco.Domain.Entities;
using MediatR;

namespace QuestaoCinco.Application.ContasCorrente.Commands
{
    public abstract class ContaCorrenteCommand : IRequest<ContaCorrente>
    {
        public string ContaId { get; set; }

        public string NomeTitular { get; set; }

        public decimal? ValorInicial { get; set; }

        public decimal? SaldoAtual { get; set; }

    }
}
