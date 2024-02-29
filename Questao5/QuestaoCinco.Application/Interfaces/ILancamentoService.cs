using QuestaoCinco.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestaoCinco.Application.Interfaces
{
    public interface ILancamentoService
    {
        Task<IEnumerable<LancamentoDTO>> GetLancamentos();
        Task Add(LancamentoCreateDTO lancamentoCreateDTO);
        Task Update(LancamentoDTO lancamentoDTO);
        Task Remove(int? id);
    }
}
