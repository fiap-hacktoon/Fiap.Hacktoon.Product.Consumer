namespace Fiap.Hackatoon.Product.Consumer.Application.DataTransferObjects;

public record Product(
    Guid Id,
    DateTime CreatedAt,
    DateTime? RemovedAt,
    bool Removed,
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    int Status,
    Guid TypeId
);
