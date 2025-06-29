using DO = Fiap.Hackatoon.Product.Consumer.Domain.Entities;

namespace Fiap.Hackatoon.Product.Consumer.Domain.Interfaces;

public interface IProductService : IBaseService<DO.Product>
{
    Task<DO.Product> GetById(Guid id, bool include, bool tracking);
    Task Remove(Guid id);
}