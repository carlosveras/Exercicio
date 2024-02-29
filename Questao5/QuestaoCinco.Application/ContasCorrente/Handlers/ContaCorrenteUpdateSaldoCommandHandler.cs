using QuestaoCinco.Application.ContasCorrente.Commands;
using QuestaoCinco.Domain.Entities;
using QuestaoCinco.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QuestaoCinco.Application.Products.Handlers
{
    public class ContaCorrenteUpdateSaldoCommandHandler : IRequestHandler<ContaCorrenteUpdateSaldoCommand, ContaCorrente>
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        public ContaCorrenteUpdateSaldoCommandHandler(IContaCorrenteRepository contaCorrenteRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository ??
            throw new ArgumentNullException(nameof(contaCorrenteRepository));
        }

        public async Task<ContaCorrente> Handle(ContaCorrenteUpdateSaldoCommand request,
            CancellationToken cancellationToken)
        {
            var contaCorrente = await _contaCorrenteRepository.GetByIdAsync(request.ContaId);

            if (contaCorrente == null)
                throw new ApplicationException($"Entity could not be found.");
            else
            {
                contaCorrente.UpdateSaldoAtual(request.SaldoAtual);

                return await _contaCorrenteRepository.UpdateAsync(contaCorrente);
            }
        }
    }
}
