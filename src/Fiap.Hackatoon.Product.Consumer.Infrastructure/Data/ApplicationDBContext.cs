using Microsoft.EntityFrameworkCore;

namespace Fiap.Hackatoon.Product.Consumer.Infrastructure.Data;

public class ApplicationDBContext : DbContext
{ 
    public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDBContext).Assembly);
    }
}