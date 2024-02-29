using QuestaoCinco.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestaoCinco.Application.Interfaces
{
    public interface IContaCorrenteService
    {
        Task<IEnumerable<ContaCorrenteDTO>> GetContas();

        Task<ContaCorrenteDTO> GetById(string id);

        Task<ContaCorrenteSaldoDTO> GetSaldoByContaId(string id);

        Task<ContaCorrenteAlteraDTO> Add(ContaCorrenteCreateDTO contaCorrenteCreateDTO);

        Task<ContaCorrenteAlteraDTO> Update(ContaCorrenteAlteraDTO contaCorrenteDTO);

        Task UpdateSaldoByContaId (ContaCorrenteSaldoDTO contaCorrenteDTO);

        Task Remove(string id);
    }
}
