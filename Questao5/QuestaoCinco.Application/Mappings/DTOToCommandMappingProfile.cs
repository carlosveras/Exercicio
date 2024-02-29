using AutoMapper;
using QuestaoCinco.Application.ContasCorrente.Commands;
using QuestaoCinco.Application.DTOs;
using QuestaoCinco.Application.Lancamentos.Commands;

namespace QuestaoCinco.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
           
            CreateMap<ContaCorrenteDTO,       ContaCorrenteCreateCommand>();
            CreateMap<ContaCorrenteCreateDTO, ContaCorrenteCreateCommand>();
            CreateMap<ContaCorrenteAlteraDTO, ContaCorrenteUpdateCommand>();

            CreateMap<ContaCorrenteDTO, ContaCorrenteUpdateCommand>();
            CreateMap<ContaCorrenteDTO, ContaCorrenteUpdateSaldoCommand>();

            CreateMap<ContaCorrenteCreateDTO, ContaCorrenteAlteraDTO>();

            CreateMap<ContaCorrenteSaldoDTO, ContaCorrenteUpdateSaldoCommand>();


            CreateMap<LancamentoDTO, LancamentoCreateCommand>();
            CreateMap<LancamentoDTO, LancamentoUpdateCommand>();

            CreateMap<LancamentoCreateDTO, LancamentoCreateCommand>();


        }
    }
}
