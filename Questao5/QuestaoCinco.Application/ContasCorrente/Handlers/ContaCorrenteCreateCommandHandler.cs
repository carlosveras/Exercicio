using QuestaoCinco.Application.ContasCorrente.Commands;
using QuestaoCinco.Domain.Entities;
using QuestaoCinco.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QuestaoCinco.Application.ContasCorrente.Handlers
{
    public class ContaCorrenteCreateCommandHandler : IRequestHandler<ContaCorrenteCreateCommand, ContaCorrente>
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        public ContaCorrenteCreateCommandHandler(IContaCorrenteRepository contaCorrenteRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
        }
        public async Task<ContaCorrente> Handle(ContaCorrenteCreateCommand request, CancellationToken cancellationToken)
        {
            var contaCorrente = new ContaCorrente(request.ContaId, request.NomeTitular, request.ValorInicial);

            if (contaCorrente == null)
                throw new ApplicationException($"Error creating entity.");

            return await _contaCorrenteRepository.CreateAsync(contaCorrente);
        }

    }
}
