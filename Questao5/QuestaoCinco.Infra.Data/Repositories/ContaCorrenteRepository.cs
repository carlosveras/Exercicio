using QuestaoCinco.Domain.Entities;
using QuestaoCinco.Domain.Interfaces;
using QuestaoCinco.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestaoCinco.Infra.Data.Repositories
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private ApplicationDbContext _contaCorrenteContext;
        public ContaCorrenteRepository(ApplicationDbContext context)
        {
            _contaCorrenteContext = context;
        }

        public async Task<ContaCorrente> CreateAsync(ContaCorrente contaCorrente)
        {
            _contaCorrenteContext.Add(contaCorrente);
            await _contaCorrenteContext.SaveChangesAsync();
            return contaCorrente;
        }

        public async Task<ContaCorrente> GetByIdAsync(string id)
        {
            return await _contaCorrenteContext.ContasCorrente
                                              .Include(l => l.Lancamentos)
                                              .SingleOrDefaultAsync(p => p.ContaId == id);
        }

        public async Task<IEnumerable<ContaCorrente>> GetContasAsync()
        {
            return await _contaCorrenteContext.ContasCorrente.ToListAsync();
        }

        public async Task<ContaCorrente> GetSaldoByContaIdAsync(string id)
        {
            return await _contaCorrenteContext.ContasCorrente
                                              .SingleOrDefaultAsync(p => p.ContaId == id);
        }

        public async Task<ContaCorrente> RemoveAsync(ContaCorrente contaCorrente)
        {
            _contaCorrenteContext.Remove(contaCorrente);
            await _contaCorrenteContext.SaveChangesAsync();
            return contaCorrente;
        }

        public async Task<ContaCorrente> UpdateAsync(ContaCorrente contaCorrente)
        {
            _contaCorrenteContext.Update(contaCorrente);
            await _contaCorrenteContext.SaveChangesAsync();
            return contaCorrente;
        }

        public async Task<ContaCorrente> UpdateSaldoByContaIdAsync(ContaCorrente contaCorrente)
        {
            contaCorrente = await _contaCorrenteContext.ContasCorrente.SingleOrDefaultAsync(p => p.ContaId == contaCorrente.ContaId);

            _contaCorrenteContext.Update(contaCorrente);
            await _contaCorrenteContext.SaveChangesAsync();
            return contaCorrente;
        }
    }
}
