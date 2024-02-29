using QuestaoCinco.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestaoCinco.Domain.Interfaces
{
    public interface IContaCorrenteRepository
    {
        Task<IEnumerable<ContaCorrente>> GetContasAsync();
        Task<ContaCorrente> GetByIdAsync(string id);
        Task<ContaCorrente> GetSaldoByContaIdAsync(string id);
        Task<ContaCorrente> CreateAsync(ContaCorrente contaCorrente);
        Task<ContaCorrente> UpdateAsync(ContaCorrente contaCorrente);
        Task<ContaCorrente> RemoveAsync(ContaCorrente contaCorrente);
        Task<ContaCorrente> UpdateSaldoByContaIdAsync(ContaCorrente contaCorrente);

    }
}
