using QuestaoCinco.Domain.Entities;
using QuestaoCinco.Domain.Interfaces;
using QuestaoCinco.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuestaoCinco.Infra.Data.Repositories
{
    //public class LancamentoRepository : ILancamentoRepository
    //{
    //    private ApplicationDbContext _lancamentoContext;
    //    public LancamentoRepository(ApplicationDbContext lancamentoContext)
    //    {
    //        _lancamentoContext = lancamentoContext;
    //    }

    //    public async Task<Lancamento> CreateAsync(Lancamento lancamento)
    //    {
    //        _lancamentoContext.Add(lancamento);
    //        await _lancamentoContext.SaveChangesAsync();
    //        return lancamento;
    //    }

    //    public async Task<Lancamento> GetByIdAsync(int? id)
    //    {
    //        return await _lancamentoContext.Lancamentos.SingleOrDefaultAsync(p => p.LancamentoId == id);
    //    }

    //    public async Task<IEnumerable<Lancamento>> GetLancamentosAsync()
    //    {
    //        return await _lancamentoContext.Lancamentos.ToListAsync();
    //    }

    //    public async Task<Lancamento> RemoveAsync(Lancamento lancamento)
    //    {
    //        _lancamentoContext.Remove(lancamento);
    //        await _lancamentoContext.SaveChangesAsync();
    //        return lancamento;
    //    }

    //    public async Task<Lancamento> UpdateAsync(Lancamento lancamento)
    //    {
    //        _lancamentoContext.Update(lancamento);
    //        await _lancamentoContext.SaveChangesAsync();
    //        return lancamento;
    //    }
    //}
    public class LancamentoRepository : ILancamentoRepository
    {
        private readonly ApplicationDbContext _context;

        public LancamentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Lancamento>> GetLancamentosAsync()
        {
            return await _context.Lancamentos.ToListAsync();
        }

        public async Task<Lancamento> GetByIdAsync(int? id)
        {
            return await _context.Lancamentos.FindAsync(id);
        }

        public async Task<Lancamento> CreateAsync(Lancamento lancamento)
        {
            _context.Lancamentos.Add(lancamento);
            await _context.SaveChangesAsync();
            return lancamento;
        }

        public async Task<Lancamento> UpdateAsync(Lancamento lancamento)
        {
            _context.Entry(lancamento).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return lancamento;
        }

        public async Task<Lancamento> RemoveAsync(Lancamento lancamento)
        {
            _context.Lancamentos.Remove(lancamento);
            await _context.SaveChangesAsync();
            return lancamento;
        }
    }



}
