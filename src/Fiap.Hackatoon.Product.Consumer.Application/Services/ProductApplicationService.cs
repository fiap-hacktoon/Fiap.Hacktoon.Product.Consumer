using System.Text.Json;
using AutoMapper;
using Fiap.Hackatoon.Product.Consumer.Application.Interfaces;
using Fiap.Hackatoon.Product.Consumer.Domain.Constants;
using Fiap.Hackatoon.Product.Consumer.Domain.Interfaces;
using MSG = Fiap.Hackatoon.Product.Consumer.Application.DataTransferObjects.MessageBrokers;
using DTO = Fiap.Hackatoon.Product.Consumer.Application.DataTransferObjects;
using DO = Fiap.Hackatoon.Product.Consumer.Domain.Entities;

namespace Fiap.Hackatoon.Product.Consumer.Application.Services;

public class ProductApplicationService(
    IProductService productService,
    IProductTypeService productTypeService,
    IMapper mapper) : IProductApplicationService
{
    private readonly IProductService _productService = productService;
    private readonly IProductTypeService _productTypeService = productTypeService;
    private readonly IMapper _mapper = mapper;

    public async Task Consumer(string message, string rountingKey)
    {
        switch(rountingKey)
        {
            case AppConstants.Routes.RabbitMQ.ProductInsert:
                var productInserted = JsonSerializer.Deserialize<MSG.Product>(message);
                await Insert(productInserted);
                break;

            case AppConstants.Routes.RabbitMQ.ProductUpdate:
                var productUpdated = JsonSerializer.Deserialize<MSG.Product>(message);
                await Update(productUpdated);
                break;

            case AppConstants.Routes.RabbitMQ.ProductDelete:
                var productRemoved = JsonSerializer.Deserialize<MSG.Identifier>(message);
                await Remove(productRemoved.Id);
                break;
        }
    }

    public async Task<DTO.Product> Insert(MSG.Product model)
    {
        var product = await _productService.GetById(model.Id, include: false, tracking: false);
        if (product != null)
            await Update(model);

        var entity = model.ToEntity(_mapper) as DO.Product;

        var result = await _productService.Add(entity);
        return _mapper.Map<DTO.Product>(result);
    }

    public async Task<DTO.Product> Update(MSG.Product model)
    {
        var product = await _productService.GetById(model.Id, include: false, tracking: true);
        if (product == null)
            await Insert(model);

        _mapper.Map(model, product);

        var result = await _productService.Update(product);
        return _mapper.Map<DTO.Product>(result);
    }

    public async Task Remove(Guid id)
    {
        await _productService.Remove(id);
    }

    public void Dispose()
    {
        _productService.Dispose();

        GC.SuppressFinalize(this);
    }
}
