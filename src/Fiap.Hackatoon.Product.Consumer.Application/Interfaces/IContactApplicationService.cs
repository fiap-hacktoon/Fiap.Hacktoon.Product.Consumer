using Fiap.Hackatoon.Product.Consumer.Application.DataTransferObjects;
using Fiap.Hackatoon.Product.Consumer.Application.Interfaces.RabbitMQ;

namespace Fiap.Hackatoon.Product.Consumer.Application.Interfaces;

public interface IProductApplicationService : IBaseRabbitMQConsumer
{   
    Task Remove(Guid id);
}