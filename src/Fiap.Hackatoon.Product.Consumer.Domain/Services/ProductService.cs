using System.ComponentModel.DataAnnotations;
using DO = Fiap.Hackatoon.Product.Consumer.Domain.Entities;
using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces;
using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces.Infrastructure;

namespace Fiap.Hackatoon.Product.Consumer.Domain.Services;

public class ProductService(IProductRepository productRepository) : BaseService<DO.Product>(productRepository), IProductService
{
    private readonly IProductRepository _contactRepository = productRepository;

    public async Task<DO.Product> GetById(Guid id, bool include, bool tracking)
    {
        var entity = await _contactRepository.GetById(id, include, tracking);

        if (entity == null)
            throw new ValidationException("O contato não existe.");

        return entity;
    }

    public async Task Remove(Guid id)
    {
        var entity = await _contactRepository.GetById(id, false, true);
        if (entity == null)
            throw new Exception("O contato não existe.");

        await base.Remove(entity);
    }

    public override async Task<DO.Product> Add(DO.Product entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "O contato não pode ser nulo.");

        entity.PrepareToInsert();

        return await base.Add(entity);
    }

    public override async Task<DO.Product> Update(DO.Product entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity), "O produto não pode ser nulo.");

        entity.PrepareToUpdate();

        return await base.Update(entity);
    }
}