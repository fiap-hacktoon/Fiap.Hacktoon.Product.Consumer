using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DO = Fiap.Hackatoon.Product.Consumer.Domain.Entities;
using Fiap.Hackatoon.Product.Consumer.Domain.Enums;

namespace Fiap.Hackatoon.Product.Consumer.Infrastructure.Data.Configurations;

public class ContactConfiguration : BaseEntityConfiguration<DO.Product>
{
    public override void Configure(EntityTypeBuilder<DO.Product> builder)
    {
        base.Configure(builder);

        builder.Property(p => p.Name).IsRequired().HasMaxLength(50);
        builder.Property(p => p.Description).IsRequired().HasMaxLength(250);
        builder.Property(p => p.Price).HasColumnType("decimal(15,2)").IsRequired();
        builder.Property(p => p.StockQuantity).IsRequired();
        builder.Property(p => p.Status).IsRequired();

        builder.HasOne(p => p.Type)
            .WithMany(t => t.Products)
            .HasForeignKey(p => p.TypeId);
    }
}