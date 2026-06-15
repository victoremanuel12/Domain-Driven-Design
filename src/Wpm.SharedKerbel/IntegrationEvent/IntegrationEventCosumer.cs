using Azure.Messaging.ServiceBus;
using Wpm.SharedKerbel.IntegrationEvent.interfaces;

public class AzureServiceBusConsumer : IIntegrationEventConsumer
{
    private readonly ServiceBusClient _client;

    public AzureServiceBusConsumer(ServiceBusClient client)
    {
        _client = client;
    }

    public async Task StartAsync(
        string queueName,
        Func<string, Task> handler,
        CancellationToken cancellationToken)
    {
        var processor = _client.CreateProcessor(
            queueName,
            new ServiceBusProcessorOptions
            {
                AutoCompleteMessages = false
            });

        processor.ProcessMessageAsync += async args =>
        {
            try
            {
                var body = args.Message.Body.ToString();

                await handler(body);

                await args.CompleteMessageAsync(args.Message);
            }
            catch
            {
                await args.AbandonMessageAsync(args.Message);

                throw;
            }
        };

        processor.ProcessErrorAsync += args =>
        {
            Console.WriteLine(args.Exception);

            return Task.CompletedTask;
        };

        await processor.StartProcessingAsync(cancellationToken);
    }
}