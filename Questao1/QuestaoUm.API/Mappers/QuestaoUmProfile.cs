using AutoMapper;
using QuestaoUm.API.Entities;
using QuestaoUm.API.Models;

namespace QuestaoUm.API.Mappers
{
    public class QuestaoUmProfile : Profile
    {
        public QuestaoUmProfile()
        {
            CreateMap<ContaCorrente, ContaCorrenteViewModel>();
            CreateMap<ContaCorrente, ContaCorrenteSaldoViewModel>();
            CreateMap<Lancamento, LancamentoViewModel>();

            CreateMap<ContaCorrenteInputModel, ContaCorrente>();
            CreateMap<ContaCorrenteUpdateModel, ContaCorrente>();
            CreateMap<LancamentoInputModel, Lancamento>();
        }
    }
}
