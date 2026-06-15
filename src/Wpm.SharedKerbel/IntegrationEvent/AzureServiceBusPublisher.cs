using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using System.Net.Mime;
using Wpm.SharedKerbel.Abstract;
using Wpm.SharedKerbel.IntegrationEvent.Wpm.SharedKernel.Messaging;

namespace Wpm.SharedKerbel.IntegrationEvent
{
    public class AzureServiceBusPublisher : IIntegrationEventPublisher
    {
        private readonly ServiceBusClient _client;

        public AzureServiceBusPublisher(ServiceBusClient client)
        {
            _client = client;
        }

        public async Task PublishAsync(IIntegrationEvent integrationEvent, string topicName)
        {
            await using var sender = _client.CreateSender(topicName);
            var message = new ServiceBusMessage(JsonConvert.SerializeObject(integrationEvent))
            {
                MessageId = Guid.NewGuid().ToString(),
                Subject = integrationEvent.GetType().Name,
                ContentType = MediaTypeNames.Application.Json
            };

            await sender.SendMessageAsync(message);
        }
    }
}