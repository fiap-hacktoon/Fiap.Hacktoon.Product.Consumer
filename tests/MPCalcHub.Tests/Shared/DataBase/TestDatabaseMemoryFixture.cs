using Microsoft.EntityFrameworkCore;
using Fiap.Hackatoon.Product.Consumer.Infrastructure.Data;

namespace Fiap.Hackatoon.Product.Consumer.Tests.Shared.DataBase;

public class TestDatabaseMemoryFixture : IDisposable
{
    public ApplicationDBContext Context { get; private set; }

    public TestDatabaseMemoryFixture()
    {
        var options = new DbContextOptionsBuilder<ApplicationDBContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        Context = new ApplicationDBContext(options);

        Context.Database.EnsureDeleted();
        Context.Database.EnsureCreated();
    }

    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}
