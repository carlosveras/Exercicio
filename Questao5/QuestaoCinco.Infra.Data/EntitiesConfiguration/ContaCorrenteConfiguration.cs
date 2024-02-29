using QuestaoCinco.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuestaoCinco.Infra.Data.EntitiesConfiguration
{
    public class ContaCorrenteConfiguration : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.HasKey(c => c.ContaId);

            builder.Property(c => c.ContaId).HasMaxLength(50).HasColumnType("varchar(50)");

            builder.Property(c => c.NomeTitular).HasMaxLength(200).HasColumnType("varchar(200)");

            builder.Property(c => c.ValorInicial).HasColumnType("decimal(10,2)");

            builder.Property(c => c.SaldoAtual).HasColumnType("decimal(10,2)");

            builder.HasMany(de => de.Lancamentos).WithOne().HasForeignKey(s => s.ContaId);
        }
    }
}
