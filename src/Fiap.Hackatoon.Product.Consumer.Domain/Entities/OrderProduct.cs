namespace Fiap.Hackatoon.Product.Consumer.Domain.Entities;

public class OrderProduct : BaseEntity
{
    public Guid OrderId { get; set; }
    public Order Order { get; set; } = null!;

    public Guid ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public int Quantity { get; set; }
    public decimal OrderPrice { get; set; }
}