using Fiap.Hackatoon.Product.Consumer.Domain.Entities;
using Fiap.Hackatoon.Product.Consumer.Infrastructure.Data;
using Fiap.Hackatoon.Product.Consumer.Tests.Shared.DataBase;

namespace Fiap.Hackatoon.Product.Consumer.Tests.Domain.Services;

public abstract class BaseServiceTests : IDisposable
{
    protected ApplicationDBContext _context;
    private readonly TestDatabaseMemoryFixture _dbFixture;

    protected BaseServiceTests()
    {
        _dbFixture = new TestDatabaseMemoryFixture();
        _context = _dbFixture.Context;
    }

    protected async Task SaveChanges()
    {
        await _context.SaveChangesAsync();
    }

    public virtual void Dispose()
    {
        _context?.Dispose();
        _dbFixture.Dispose();
        GC.SuppressFinalize(this);
    }
}