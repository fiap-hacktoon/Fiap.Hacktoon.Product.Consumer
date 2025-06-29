namespace Fiap.Hackatoon.Product.Consumer.Domain.Entities;

public record class OrderProduct(

    Guid Id,
    DateTime CreatedAt,
    DateTime? RemovedAt,
    bool Removed
);

