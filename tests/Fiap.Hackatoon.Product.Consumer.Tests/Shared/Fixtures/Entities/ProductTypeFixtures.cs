using Bogus;
using Fiap.Hackatoon.Product.Consumer.Domain.Entities;
using Fiap.Hackatoon.Product.Consumer.Tests.Shared.Fixtures.Utils;

namespace Fiap.Hackatoon.Product.Consumer.Tests.Shared.Fixtures;

public sealed class ProductTypeFixtures : BaseFixtures<ProductType>
{
    public ProductTypeFixtures() : base() { }

    public static ProductType CreateAs_Base()
    {
        var type = new ProductType()
        {
            Id = FakerDefault.Random.Guid(),
            Name = FakerDefault.Random.String2(5, 20),
            Description = FakerDefault.Random.String2(10, 50),
            Code = FakerDefault.Random.String2(3, 10),
        };

        return type;
    }
}