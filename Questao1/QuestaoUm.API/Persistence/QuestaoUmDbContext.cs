using QuestaoUm.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace QuestaoUm.API.Persistence;

public class QuestaoUmDbContext : DbContext
{
    public QuestaoUmDbContext(DbContextOptions<QuestaoUmDbContext> options) : base(options)
    {
    }
    public DbSet<ContaCorrente> ContasCorrente { get; set; }
    public DbSet<Lancamento> Lancamentos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Lancamento>(e =>
        {
            e.HasKey(l => l.LancamentoId);

            e.Property(c => c.ContaId).HasMaxLength(50).HasColumnType("varchar(50)");

            e.Property(c => c.SaldoAntes).HasColumnType("decimal(10,2)");

            e.Property(c => c.SaldoApos).HasColumnType("decimal(10,2)");

            e.Property(c => c.Valor).HasColumnType("decimal(10,2)");

            e.Property(c => c.DebitoCredito).HasColumnType("char(1)");

            e.Property(c => c.DataTransacao).HasColumnType("datetime");
        });

        builder.Entity<ContaCorrente>(e =>
        {
            e.HasKey(c => c.ContaId);

            e.Property(c => c.ContaId).HasMaxLength(50).HasColumnType("varchar(50)");

            e.Property(c => c.NomeTitular).HasMaxLength(200).HasColumnType("varchar(200)");

            e.Property(c => c.ValorInicial).HasColumnType("decimal(10,2)");

            e.Property(c => c.SaldoAtual).HasColumnType("decimal(10,2)");

            e.HasMany(de => de.Lancamentos).WithOne().HasForeignKey(s => s.ContaId);
        });

    }
}
