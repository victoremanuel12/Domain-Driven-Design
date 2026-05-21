using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Net.Mime;
using System.Text;
using Wpm.SharedKerbel.Abstract;
using Wpm.SharedKerbel.IntegrationEvent.Wpm.SharedKernel.Messaging;

namespace Wpm.SharedKerbel.IntegrationEvent
{
    public class AzureServiceBusPublisher(string connectionString) : IntegrationEventPublisher
    {
        public async Task PublishAsync(IIntegrationEvent integrationEvent, string topicName)
        {
            var jsonMessage = JsonConvert.SerializeObject(integrationEvent);
            var body = Encoding.UTF8.GetBytes(jsonMessage);
            var client = new ServiceBusClient(connectionString);
            var sender = client.CreateSender(topicName);
            var message = new ServiceBusMessage
            {
                Body = new BinaryData(body),
                MessageId = Guid.NewGuid().ToString(),
                ContentType = MediaTypeNames.Application.Json,
                Subject = integrationEvent.GetType().Name
            };
            await sender.SendMessageAsync(message);
        }
    }
}