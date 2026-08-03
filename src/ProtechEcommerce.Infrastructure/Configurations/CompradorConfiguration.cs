using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.Infrastructure.Configurations;

public class CompradorConfiguration : IEntityTypeConfiguration<Comprador>
{
    public void Configure(EntityTypeBuilder<Comprador> builder)
    {
        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(c => c.CpfCnpj)
            .IsRequired()
            .HasMaxLength(14);

        builder.Property(c => c.DataCriacao)
            .IsRequired();
    }
}
