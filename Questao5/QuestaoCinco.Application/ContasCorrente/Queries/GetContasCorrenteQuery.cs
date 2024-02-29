using QuestaoCinco.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace QuestaoCinco.Application.ContasCorrente.Queries
{
    public class GetContasCorrenteQuery : IRequest<IEnumerable<ContaCorrente>>
    {
    }
}
