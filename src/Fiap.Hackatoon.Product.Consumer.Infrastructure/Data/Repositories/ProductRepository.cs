using Microsoft.EntityFrameworkCore;
using DO = Fiap.Hackatoon.Product.Consumer.Domain.Entities;
using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces.Infrastructure;

namespace Fiap.Hackatoon.Product.Consumer.Infrastructure.Data.Repositories;

public class ProductRepository(ApplicationDBContext context) : BaseRepository<DO.Product>(context), IProductRepository
{
    public override async Task<DO.Product> GetById(Guid id, bool include = false, bool tracking = false)
    {
        var query = BaseQuery(tracking);

        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }
}