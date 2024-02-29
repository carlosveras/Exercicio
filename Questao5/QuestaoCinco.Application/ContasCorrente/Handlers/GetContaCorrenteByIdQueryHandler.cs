using QuestaoCinco.Application.ContasCorrente.Queries;
using QuestaoCinco.Domain.Entities;
using QuestaoCinco.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace QuestaoCinco.Application.ContasCorrente.Handlers
{
    public class GetContaCorrenteByIdQueryHandler : IRequestHandler<GetContaCorrenteByIdQuery, ContaCorrente>
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        public GetContaCorrenteByIdQueryHandler(IContaCorrenteRepository contaCorrenteRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public async Task<ContaCorrente> Handle(GetContaCorrenteByIdQuery request,
             CancellationToken cancellationToken)
        {
            return await _contaCorrenteRepository.GetByIdAsync(request.Id);
        }
       
    }
}
