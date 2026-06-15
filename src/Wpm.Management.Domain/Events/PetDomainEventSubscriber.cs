using Wpm.Management.Domain;
using Wpm.Management.Domain.Events;
using Wpm.Management.Domain.Events.IntegrationEvents;
using Wpm.SharedKerbel.IntegrationEvent.Wpm.SharedKernel.Messaging;

namespace Wpm.Management.Application.EventSubscribers;

public class PetDomainEventSubscriber
{
    public PetDomainEventSubscriber(
        IIntegrationEventPublisher publisher)
    {
        DomainEvents.PetAdopted.Subscribe(async domainEvent =>
        {
            var integrationEvent =
                new PetAdoptedIntegrationEvent(
                    domainEvent.Id,
                    domainEvent.PetName,
                    domainEvent.AdoptedAt);

            await publisher.PublishAsync(
                integrationEvent,
                QueueNames.Pet.ManagementPetQueue);
        });

        DomainEvents.PetCreated.Subscribe(async domainEvent =>
        {
            var integrationEvent =
                new PetCreatedIntegrationEvent(
                    domainEvent.Id.Value,
                    domainEvent.BreedId.Value);

            await publisher.PublishAsync(
                integrationEvent,
                QueueNames.Pet.ManagementPetQueue);
        });
    }
}