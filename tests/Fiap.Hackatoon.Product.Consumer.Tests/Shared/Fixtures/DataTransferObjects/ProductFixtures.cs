using Bogus;
using MSG = Fiap.Hackatoon.Product.Consumer.Application.DataTransferObjects.MessageBrokers;
using Fiap.Hackatoon.Product.Consumer.Tests.Shared.Fixtures.Utils;
using Fiap.Hackatoon.Product.Consumer.Application.DataTransferObjects;

namespace Fiap.Hackatoon.Product.Consumer.Tests.Shared.Fixtures.DataTransferObjects;

public sealed class ProductFixtures : BaseFixtures<MSG.Product>
{
    public ProductFixtures() : base() { }

    public static MSG.Product CreateAs_Base()
    {
        var contact = new MSG.Product()
        {
            Id = FakerDefault.Random.Guid(),
            Name = FakerDefault.Random.String2(5, 20),
            Description = FakerDefault.Random.String2(10, 50),
            Price = FakerDefault.Random.Decimal(1.0m, 1000.0m),
            StockQuantity = FakerDefault.Random.Int(1, 100),
            Status = 1,
            Removed = false
        };

        return contact;
    }
}