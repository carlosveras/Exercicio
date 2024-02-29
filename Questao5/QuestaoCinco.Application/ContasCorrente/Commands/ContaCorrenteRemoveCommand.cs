using QuestaoCinco.Domain.Entities;
using MediatR;

namespace QuestaoCinco.Application.ContasCorrente.Commands
{
    public class ContaCorrenteRemoveCommand : IRequest<ContaCorrente>
    {
        public string Id { get; set; }
        public ContaCorrenteRemoveCommand(string id)
        {
            Id = id;
        }
    }
}
