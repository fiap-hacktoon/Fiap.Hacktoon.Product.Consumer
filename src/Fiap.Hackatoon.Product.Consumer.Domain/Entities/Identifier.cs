using Fiap.Hackatoon.Product.Consumer.Domain.Entities.Interfaces;

namespace Fiap.Hackatoon.Product.Consumer.Domain.Entities;

public abstract class Identifier : IIdentifier
{
    public Guid Id { get; set; }
}