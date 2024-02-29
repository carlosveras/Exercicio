using QuestaoCinco.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestaoCinco.Domain.Interfaces
{
    public interface ILancamentoRepository
    {
        Task<IEnumerable<Lancamento>> GetLancamentosAsync();
        Task<Lancamento> GetByIdAsync(int? id);
        Task<Lancamento> CreateAsync(Lancamento lancamento);
        Task<Lancamento> UpdateAsync(Lancamento lancamento);
        Task<Lancamento> RemoveAsync(Lancamento lancamento);
    }
}
