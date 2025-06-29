using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Fiap.Hackatoon.Product.Consumer.Domain.Entities.Interfaces;

namespace Fiap.Hackatoon.Product.Consumer.Infrastructure.Data.Configurations;

public class BaseEntityConfiguration<T> : BaseIdentifierConfiguration<T> where T : class, IBaseEntity
{
    public override void Configure(EntityTypeBuilder<T> builder)
    {
        base.Configure(builder);

        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.Removed).IsRequired().HasDefaultValue(false);
        builder.Property(x => x.RemovedAt).IsRequired(false);
    }
}