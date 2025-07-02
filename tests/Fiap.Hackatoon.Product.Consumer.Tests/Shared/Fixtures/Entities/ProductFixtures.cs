using Bogus;
using Fiap.Hackatoon.Product.Consumer.Domain.Entities;
using Fiap.Hackatoon.Product.Consumer.Tests.Shared.Fixtures.Utils;
using EN = Fiap.Hackatoon.Product.Consumer.Domain.Entities;
using DTO = Fiap.Hackatoon.Product.Consumer.Application.DataTransferObjects;


namespace Fiap.Hackatoon.Product.Consumer.Tests.Shared.Fixtures.Entities;

public sealed class ProductFixtures : BaseFixtures<EN.Product>
{
    public ProductFixtures() : base() { }

    public static EN.Product CreateAs_Base()
    {
        var product = new EN.Product()
        {
            Id = FakerDefault.Random.Guid(),
            Name = FakerDefault.Random.String2(5, 20),
            Description = FakerDefault.Random.String2(10, 50),
            Price = FakerDefault.Random.Decimal(1.0m, 1000.0m),
            StockQuantity = FakerDefault.Random.Int(1, 100),
            Status = 1,
            Removed = false
        };

        return product;
    }
}