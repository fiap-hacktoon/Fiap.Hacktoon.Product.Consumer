using DO = Fiap.Hackatoon.Product.Consumer.Domain.Entities;

namespace Fiap.Hackatoon.Product.Consumer.Domain.Interfaces.Infrastructure;

public interface IProductRepository : IRepository<DO.Product>
{
    Task<DO.Product> GetById(Guid id, bool include = false, bool tracking = false);
}