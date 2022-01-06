using RabbitMQ.Client;
using RabbitMQApp.WatermarkWebApp.Services.Events;
using System.Text;
using System.Text.Json;

namespace RabbitMQApp.WatermarkWebApp.Services.Publishers
{
    public class RabbitMQPublisher
    {
        private readonly RabbitMQClientService _clientService;

        public RabbitMQPublisher(RabbitMQClientService clientService)
        {
            _clientService = clientService;
        }

        public void Publish(ProductImageCreatedEvent productImageCreatedEvent) {

            var channel = _clientService.Connect();
            var bodyString = JsonSerializer.Serialize(productImageCreatedEvent);
            var bodyByte = Encoding.UTF8.GetBytes(bodyString);
            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;

            channel.BasicPublish(
                exchange: RabbitMQClientService.ExchangeName,
                RabbitMQClientService.RoutingWatermark,
                properties, bodyByte
                );
        }

    }
   
}



