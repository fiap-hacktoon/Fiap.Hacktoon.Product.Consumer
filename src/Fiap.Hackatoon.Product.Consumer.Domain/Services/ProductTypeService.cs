using DO = Fiap.Hackatoon.Product.Consumer.Domain.Entities;
using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces;
using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces.Infrastructure;

namespace Fiap.Hackatoon.Product.Consumer.Domain.Services;

public class ProductTypeService(IProductTypeRepository productTypeRepository) : BaseService<DO.ProductType>(productTypeRepository), IProductTypeService
{
    private readonly IProductTypeRepository _productRepository = productTypeRepository;

    public async Task<DO.ProductType> GetById(Guid id, bool include, bool tracking)
    {
        var entity = await _productRepository.GetById(id, include, tracking);

        return entity;
    }
}