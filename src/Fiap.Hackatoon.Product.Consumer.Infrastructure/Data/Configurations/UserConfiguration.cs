using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Fiap.Hackatoon.Product.Consumer.Domain.Entities;
using Fiap.Hackatoon.Product.Consumer.Domain.Enums;

namespace Fiap.Hackatoon.Product.Consumer.Infrastructure.Data.Configurations;

public class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
         builder.ToTable("User");

        builder.Property(u => u.Name).IsRequired().HasMaxLength(255);
        builder.Property(u => u.Email).IsRequired().HasMaxLength(255);
        builder.Property(u => u.Password).IsRequired(false).HasMaxLength(256);
        builder.Property(u => u.TypeRole).HasDefaultValue(TypeRole.Client).HasColumnType("int");
    }
}