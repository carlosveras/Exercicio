using QuestaoCinco.Application.ContasCorrente.Queries;
using QuestaoCinco.Domain.Entities;
using QuestaoCinco.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QuestaoCinco.Application.ContasCorrente.Handlers
{
    public class GetContasCorrenteQueryHandler : IRequestHandler<GetContasCorrenteQuery, IEnumerable<ContaCorrente>>
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public GetContasCorrenteQueryHandler(IContaCorrenteRepository contaCorrenteRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public async Task<IEnumerable<ContaCorrente>> Handle(GetContasCorrenteQuery request, 
            CancellationToken cancellationToken)
        {
            return await _contaCorrenteRepository.GetContasAsync();
        }
    }
}
