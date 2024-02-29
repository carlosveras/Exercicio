using AutoMapper;
using QuestaoCinco.Application.ContasCorrente.Queries;
using QuestaoCinco.Application.DTOs;
using QuestaoCinco.Application.Interfaces;
using QuestaoCinco.Application.Lancamentos.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestaoCinco.Application.Services
{
    public class LancamentoService : ILancamentoService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public LancamentoService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task Add(LancamentoCreateDTO lancamentoCreateDTO)
        {
            var lancamentoCreateCommand = _mapper.Map<LancamentoCreateCommand>(lancamentoCreateDTO);
            await _mediator.Send(lancamentoCreateCommand);
        }
                
        public async Task Update(LancamentoDTO lancamentoDTO)
        {
            var lancamentoUpdateCommand = _mapper.Map<LancamentoUpdateCommand>(lancamentoDTO);
            await _mediator.Send(lancamentoDTO);
        }

        public async Task Remove(int? id)
        {
            var lancamentoRemoveCommand = new LancamentoRemoveCommand(id.Value);
            if (lancamentoRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(lancamentoRemoveCommand);
        }

        public async Task<IEnumerable<LancamentoDTO>> GetLancamentos()
        {
            var lancamentosQuery = new GetLancamentosQuery();

            if (lancamentosQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(lancamentosQuery);

            return _mapper.Map<IEnumerable<LancamentoDTO>>(result);
        }

        //public async Task<LancamentoDTO> GetById(int? id)
        //{
        //    var lancamentoByIdQuery = new GetLancamentoByIdQuery(id.Value);

        //    if (lancamentoByIdQuery == null)
        //        throw new Exception($"Entity could not be loaded.");

        //    var result = await _mediator.Send(lancamentoByIdQuery);

        //    return _mapper.Map<LancamentoDTO>(result);
        //}

    }
}
