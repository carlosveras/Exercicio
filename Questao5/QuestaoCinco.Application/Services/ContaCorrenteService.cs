using AutoMapper;
using QuestaoCinco.Application.ContasCorrente.Commands;
using QuestaoCinco.Application.ContasCorrente.Queries;
using QuestaoCinco.Application.DTOs;
using QuestaoCinco.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestaoCinco.Application.Services
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public ContaCorrenteService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<ContaCorrenteDTO>> GetContas()
        {
            var contasCorrenteQuery = new GetContasCorrenteQuery();

            if (contasCorrenteQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(contasCorrenteQuery);

            return _mapper.Map<IEnumerable<ContaCorrenteDTO>>(result);
        }

        public async Task<ContaCorrenteDTO> GetById(string id)
        {
            var contaCorrenteByIdQuery = new GetContaCorrenteByIdQuery(id);

            if (contaCorrenteByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(contaCorrenteByIdQuery);

            return _mapper.Map<ContaCorrenteDTO>(result);
        }

        public async Task<ContaCorrenteSaldoDTO> GetSaldoByContaId(string id)
        {
            var contaCorrenteByIdQuery = new GetContaCorrenteByIdQuery(id);

            if (contaCorrenteByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var result = await _mediator.Send(contaCorrenteByIdQuery);

            return _mapper.Map<ContaCorrenteSaldoDTO>(result);
        }

        public async Task<ContaCorrenteAlteraDTO> Add(ContaCorrenteCreateDTO contaCorrenteDTO)
        {
            var contaCorrenteCreateCommand = _mapper.Map<ContaCorrenteCreateCommand>(contaCorrenteDTO);
            await _mediator.Send(contaCorrenteCreateCommand);

            var contaCorrenteAlteraDTO = _mapper.Map<ContaCorrenteAlteraDTO>(contaCorrenteDTO);

            return contaCorrenteAlteraDTO;
        }

        public async Task<ContaCorrenteAlteraDTO> Update(ContaCorrenteAlteraDTO contaCorrenteDTO)
        {
                var contaCorrenteUpdateCommand = _mapper.Map<ContaCorrenteUpdateCommand>(contaCorrenteDTO);
                await _mediator.Send(contaCorrenteUpdateCommand);
                
                return contaCorrenteDTO; 
        }

        public async Task Remove(string id)
        {
            var contaCorrenteRemoveCommand = new ContaCorrenteRemoveCommand(id);
            if (contaCorrenteRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(contaCorrenteRemoveCommand);
        }
      
        public async Task UpdateSaldoByContaId(ContaCorrenteSaldoDTO contaCorrenteSaldoDTO)
        {
            var contaCorrenteUpdateSaldoCommand = _mapper.Map<ContaCorrenteUpdateSaldoCommand>(contaCorrenteSaldoDTO);
            await _mediator.Send(contaCorrenteUpdateSaldoCommand);
        }
    }
}
