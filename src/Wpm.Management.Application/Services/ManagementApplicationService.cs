using Wpm.Management.Application.Commands;
using Wpm.Management.Domain;
using Wpm.Management.Domain.Events;
using Wpm.Management.Domain.Events.IntegrationEvents;
using Wpm.Management.Domain.Repositories;
using Wpm.Management.Domain.Services.Interfaces;
using Wpm.Management.Domain.ValueObjects;
using Wpm.SharedKerbel.IntegrationEvent.Wpm.SharedKernel.Messaging;

namespace Wpm.Management.Application.Services
{
    public class ManagementApplicationService
    {
        private readonly IBreedService _breedService;
        private readonly IPetRepository _repository;
        private readonly IIntegrationEventPublisher _publisher;

        public ManagementApplicationService(
            IBreedService breedService,
            IIntegrationEventPublisher publisher,
            IPetRepository repository)
        {
            _breedService = breedService;
            _repository = repository;
            _publisher = publisher;
            DomainEvents.PetCreated.Subscribe(async (domainEvent) =>
            {
                var integrationEvent = new PetCreatedIntegrationEvent(domainEvent.Id.Value, domainEvent.BreedId.Value);
                await _publisher.PublishAsync(integrationEvent, QueueNames.Pet.ManagementPetQueue);

            });
        }

        public async Task Handle(CreatePetCommand command)
        {
            var newPet = Pet.Create(
                command.Name,
                command.Age,
                command.SexOfPet,
                command.Color,
                BreedId.Create(command.BreedId)
            );

            await _repository.AddAsync(newPet);
            await _repository.SaveChangesAsync();

        }
    }
}