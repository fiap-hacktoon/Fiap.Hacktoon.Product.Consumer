using DO = Fiap.Hackatoon.Product.Consumer.Domain.Entities;

namespace Fiap.Hackatoon.Product.Consumer.Domain.Interfaces.Infrastructure;

public interface IProductTypeRepository : IRepository<DO.ProductType>
{
    Task<DO.ProductType> GetById(Guid id, bool include = false, bool tracking = false);
}