using QuestaoCinco.Domain.Entities;
using MediatR;

namespace QuestaoCinco.Application.Lancamentos.Commands
{
    public class LancamentoRemoveCommand : IRequest<Lancamento>
    {
        public int LancamentoId { get; set; }
        public LancamentoRemoveCommand(int id)
        {
            LancamentoId = id;
        }
    }
}
