using AutoMapper;
using Fiap.Hackatoon.Product.Consumer.Domain.Entities;
using DO = Fiap.Hackatoon.Product.Consumer.Domain.Entities;

namespace Fiap.Hackatoon.Product.Consumer.Application.DataTransferObjects.MessageBrokers;

public class Product
{
    public Guid? Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool Removed { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public decimal Price { get; set; }
    public int StockQuantity { get; set; }
    public int Status { get; set; }
    public Guid TypeId { get; set; }

    public BaseEntity ToEntity(IMapper mapper)
    {
        var entity = mapper.Map<DO.Product>(this);

        return entity;
    }
}
