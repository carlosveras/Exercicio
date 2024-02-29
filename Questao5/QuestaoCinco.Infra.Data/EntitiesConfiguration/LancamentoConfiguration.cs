using QuestaoCinco.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuestaoCinco.Infra.Data.EntitiesConfiguration
{
    public class LancamentoConfiguration : IEntityTypeConfiguration<Lancamento>
    {
        public void Configure(EntityTypeBuilder<Lancamento> builder)
        {
            builder.HasKey(l => l.LancamentoId);

            builder.Property(c => c.ContaId).HasMaxLength(50).HasColumnType("varchar(50)");

            builder.Property(c => c.SaldoAntes).HasColumnType("decimal(10,2)");

            builder.Property(c => c.SaldoApos).HasColumnType("decimal(10,2)");

            builder.Property(c => c.Valor).HasColumnType("decimal(10,2)");

            builder.Property(c => c.DebitoCredito).HasColumnType("char(1)");

            builder.Property(c => c.DataTransacao).HasColumnType("datetime");
        }
    }
}
