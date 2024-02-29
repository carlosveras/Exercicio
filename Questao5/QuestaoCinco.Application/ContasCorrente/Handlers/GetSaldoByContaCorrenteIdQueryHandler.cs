using QuestaoCinco.Application.ContasCorrente.Queries;
using QuestaoCinco.Domain.Entities;
using QuestaoCinco.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace QuestaoCinco.Application.ContasCorrente.Handlers
{
    public class GetSaldoByContaCorrenteIdQueryHandler : IRequestHandler<GetContaCorrenteByIdQuery, ContaCorrente>
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        public GetSaldoByContaCorrenteIdQueryHandler(IContaCorrenteRepository contaCorrenteRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public async Task<ContaCorrente> Handle(GetContaCorrenteByIdQuery request,
             CancellationToken cancellationToken)
        {
            return await _contaCorrenteRepository.GetSaldoByContaIdAsync(request.Id);
        }
       
    }
}
