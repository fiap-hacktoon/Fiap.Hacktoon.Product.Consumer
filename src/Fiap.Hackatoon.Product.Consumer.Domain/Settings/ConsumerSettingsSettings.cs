namespace Fiap.Hackatoon.Product.Consumer.Domain.Settings;

public class ConsumerSettings
{
    public RabbitMQSettings RabbitMQ { get; set; }
    public ElasticSearchSettings ElasticSearch { get; set; }
}