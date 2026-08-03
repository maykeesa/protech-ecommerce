using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProtechEcommerce.Domain.Entities;

namespace ProtechEcommerce.Infrastructure.Configurations;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.Property(p => p.Status)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.HasOne(p => p.Comprador)
            .WithMany()
            .HasForeignKey(p => p.CompradorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
