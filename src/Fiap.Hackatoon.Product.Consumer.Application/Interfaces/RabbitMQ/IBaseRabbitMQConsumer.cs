namespace Fiap.Hackatoon.Product.Consumer.Application.Interfaces.RabbitMQ
{
    public interface IBaseRabbitMQConsumer : IDisposable
    {
        Task Consumer(string message, string rountingKey);
    }
}