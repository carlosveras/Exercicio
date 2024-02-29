using QuestaoCinco.Domain.Entities;
using MediatR;

namespace QuestaoCinco.Application.ContasCorrente.Queries
{
    public class GetContaCorrenteByIdQuery : IRequest<ContaCorrente>
    {
        public string Id { get; set; }
        public GetContaCorrenteByIdQuery(string id)
        {
            Id = id;
        }
    }
}
