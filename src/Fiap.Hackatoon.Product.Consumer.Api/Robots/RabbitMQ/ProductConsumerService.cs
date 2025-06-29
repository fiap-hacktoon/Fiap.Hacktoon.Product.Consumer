using Fiap.Hackatoon.Product.Consumer.Domain.Constants;
using Fiap.Hackatoon.Product.Consumer.Application.Interfaces;
using Fiap.Hackatoon.Product.Consumer.Domain.Settings;
using Microsoft.Extensions.Options;

namespace Fiap.Hackatoon.Product.Consumer.Api.Robots.RabbitMQ
{
    public class ProductConsumerService : BaseRabbitMQConsumerService
    {
        public override string Queue => "hacktoon.product";

        public override string RoutingKey => "product.*";

        public ProductConsumerService(IServiceProvider serviceProvider, IOptions<ConsumerSettings> settings,  ILogger<ProductConsumerService> logger)
            : base(serviceProvider, settings, logger)
        {
            ServiceMaps.Add(AppConstants.Routes.RabbitMQ.ProductInsert, sp => serviceProvider.GetService<IProductApplicationService>());
            ServiceMaps.Add(AppConstants.Routes.RabbitMQ.ProductUpdate, sp => serviceProvider.GetService<IProductApplicationService>());
            ServiceMaps.Add(AppConstants.Routes.RabbitMQ.ProductDelete, sp => serviceProvider.GetService<IProductApplicationService>());
        }
    }
}