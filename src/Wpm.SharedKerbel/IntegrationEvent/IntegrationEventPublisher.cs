using Wpm.SharedKerbel.Abstract;

namespace Wpm.SharedKerbel.IntegrationEvent
{
    namespace Wpm.SharedKernel.Messaging
    {
        public interface IntegrationEventPublisher
        {
            public Task PublishAsync(IIntegrationEvent integrationEvent, string topicName);
        }
    }
}
