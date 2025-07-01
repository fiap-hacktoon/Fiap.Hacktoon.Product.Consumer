using DO = Fiap.Hackatoon.Product.Consumer.Domain.Entities;

namespace Fiap.Hackatoon.Product.Consumer.Domain.Interfaces;

public interface IProductTypeService : IBaseService<DO.ProductType>
{
    Task<DO.ProductType> GetById(Guid id, bool include, bool tracking);
}