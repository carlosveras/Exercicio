using QuestaoCinco.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace QuestaoCinco.Application.ContasCorrente.Queries
{
    public class GetLancamentosQuery : IRequest<IEnumerable<Lancamento>>
    {
    }
}
