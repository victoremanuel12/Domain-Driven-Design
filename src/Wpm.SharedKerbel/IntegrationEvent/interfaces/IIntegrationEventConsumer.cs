namespace Wpm.SharedKerbel.IntegrationEvent.interfaces
{
    public interface IIntegrationEventConsumer
    {
        Task StartAsync(
            string queueName,
            Func<string, Task> handler,
            CancellationToken cancellationToken);
    }
}
