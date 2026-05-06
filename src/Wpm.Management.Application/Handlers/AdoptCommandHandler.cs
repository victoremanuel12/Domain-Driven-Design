using Wpm.Management.Application.Commands;
using Wpm.Management.Domain;
using Wpm.Management.Domain.Events;
using Wpm.Management.Domain.Events.IntegrationEvents;
using Wpm.Management.Domain.Repositories;
using Wpm.SharedKerbel.Abstract;
using Wpm.SharedKerbel.IntegrationEvent.Wpm.SharedKernel.Messaging;

namespace Wpm.Management.Application.Handlers
{
    public class AdoptCommandHandler : ICommandHandler<AdoptPetCommand>
    {
        private readonly IPetRepository _repository;
        private readonly IntegrationEventPublisher _integrationEventPublisher;
        public AdoptCommandHandler(IPetRepository repository, IntegrationEventPublisher publisher)
        {
            _repository = repository;
            _integrationEventPublisher = publisher;
            DomainEvents.PetAdopted.Subscribe(async (domainEvent) =>
            {
                var integrationEvent = new PetAdoptedIntegrationEvent(domainEvent.Id, domainEvent.PetName, domainEvent.AdoptedAt);
                await _integrationEventPublisher.PublishAsync(integrationEvent, QueueNames.Pet.ManagementPetQueue);

            });
        }
        public async Task Handle(AdoptPetCommand command)        {
            var pet = await _repository.GetByIdAsync(command.Id);
            if (pet == null) throw new Exception($"Pet with id {command.Id} not found.");
            pet.Adopt();
        }
    }
}
