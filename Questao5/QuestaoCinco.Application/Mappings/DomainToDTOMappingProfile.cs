using AutoMapper;
using QuestaoCinco.Application.ContasCorrente.Commands;
using QuestaoCinco.Application.DTOs;
using QuestaoCinco.Domain.Entities;

namespace QuestaoCinco.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
    

            CreateMap<ContaCorrente, ContaCorrenteDTO>().ReverseMap();
            CreateMap<ContaCorrente, ContaCorrenteAlteraDTO>().ReverseMap();
            CreateMap<ContaCorrente, ContaCorrenteCreateDTO>().ReverseMap();
            CreateMap<ContaCorrente, ContaCorrenteSaldoDTO>().ReverseMap();

            //////atemcaoCreateMap<ContaCorrenteCreateDTO, ContaCorrenteAlteraDTO>().ReverseMap();

            CreateMap<ContaCorrente, ContaCorrenteUpdateSaldoCommand>().ReverseMap();

            CreateMap<Lancamento, LancamentoDTO>().ReverseMap();
            CreateMap<Lancamento, LancamentoCreateDTO>().ReverseMap();
        }
    }
}
