namespace Fiap.Hackatoon.Product.Consumer.Application.DataTransferObjects.MessageBrokers;

public record Product(
    Guid Id,
    DateTime CreatedAt,
    DateTime UpdatedAt,
    bool Removed,
    string Name,
    string Description,
    decimal Price,
    int StockQuantity,
    int Status,
    Guid ProductTypeId
);
