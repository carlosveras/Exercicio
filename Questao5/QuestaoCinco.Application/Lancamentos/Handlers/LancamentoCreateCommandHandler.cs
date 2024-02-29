using QuestaoCinco.Application.Lancamentos.Commands;
using QuestaoCinco.Domain.Entities;
using QuestaoCinco.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QuestaoCinco.Application.Lancamentos.Handlers
{
    public class LancamentoCreateCommandHandler : IRequestHandler<LancamentoCreateCommand, Lancamento>
    {
        private readonly ILancamentoRepository _lancamentoRepository;
        public LancamentoCreateCommandHandler(ILancamentoRepository lancamentoRepository)
        {
            _lancamentoRepository = lancamentoRepository;
        }
        public async Task<Lancamento> Handle(LancamentoCreateCommand request, CancellationToken cancellationToken)
        {
            var lancamento = new Lancamento(request.DebitoCredito, request.Valor, request.ContaId, request.SaldoAntes, request.SaldoApos);

            if (lancamento == null)
                throw new ApplicationException($"Error creating entity.");

            return await _lancamentoRepository.CreateAsync(lancamento);
        }

    }
}
