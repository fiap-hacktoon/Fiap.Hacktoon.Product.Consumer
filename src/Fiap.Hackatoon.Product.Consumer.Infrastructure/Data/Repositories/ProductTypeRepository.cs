using Microsoft.EntityFrameworkCore;
using DO = Fiap.Hackatoon.Product.Consumer.Domain.Entities;
using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces.Infrastructure;

namespace Fiap.Hackatoon.Product.Consumer.Infrastructure.Data.Repositories;

public class ProductTypeRepository(ApplicationDBContext context) : BaseRepository<DO.ProductType>(context), IProductTypeRepository
{
    public override async Task<DO.ProductType> GetById(Guid id, bool include = false, bool tracking = false)
    {
        var query = BaseQuery(tracking);

        return await query.FirstOrDefaultAsync(x => x.Id == id);
    }
}