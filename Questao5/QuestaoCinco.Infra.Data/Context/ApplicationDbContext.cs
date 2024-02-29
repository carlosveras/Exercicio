using QuestaoCinco.Domain.Entities;
using QuestaoCinco.Infra.Data.EntitiesConfiguration;
using Microsoft.EntityFrameworkCore;

namespace QuestaoCinco.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<ContaCorrente> ContasCorrente { get; set; }
        public DbSet<Lancamento> Lancamentos { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
