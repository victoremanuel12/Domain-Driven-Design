using Wpm.SharedKerbel.Abstract;

namespace Wpm.SharedKerbel.IntegrationEvent
{
    namespace Wpm.SharedKernel.Messaging
    {
        public interface IIntegrationEventPublisher
        {
            public Task PublishAsync(IIntegrationEvent integrationEvent, string topicName);
        }
    }
}
