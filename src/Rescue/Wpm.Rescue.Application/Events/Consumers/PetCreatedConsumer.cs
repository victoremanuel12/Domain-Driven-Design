using Newtonsoft.Json;
using Wpm.Rescue.Application.Events.IntegrationEvents;
using Wpm.SharedKerbel.IntegrationEvent.interfaces;
using Microsoft.Extensions.Hosting;

public class PetAdoptedIntegrationEventHandler : BackgroundService
{
    private readonly IIntegrationEventConsumer _consumer;

    public PetAdoptedIntegrationEventHandler(
        IIntegrationEventConsumer consumer)
    {
        _consumer = consumer;
    }

    protected override async Task ExecuteAsync(
        CancellationToken cancellationToken)
    {
        await _consumer.StartAsync(
            "first-queue",
            async body =>
            {
                var evt =
                    JsonConvert.DeserializeObject<
                        PetAdoptedIntegrationEvent>(body);

                Console.WriteLine(evt.Id);

                await Task.CompletedTask;
            },
            cancellationToken);
    }
}