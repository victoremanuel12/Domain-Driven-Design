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
        private readonly IntegrationEventPublisher _publisher;

        public ManagementApplicationService(
            IBreedService breedService,
            IntegrationEventPublisher publisher,
            IPetRepository repository)
        {
            _breedService = breedService;
            _repository = repository;
            _publisher = publisher;
            DomainEvents.PetCreated.Subscribe(async (domainEvent) =>
            {
                var integrationEvent = new PetCreatedIntegrationEvent(domainEvent.Id, domainEvent.BreedId);
                await _publisher.PublishAsync(integrationEvent, QueueNames.Pet.Created);

            });
        }

        public async Task Handle(CreatePetCommand command)
        {
            var breedId = new BreedId(command.BreedId, _breedService);

            var newPet = Pet.Create(
                command.Id,
                command.Name,
                command.Age,
                command.SexOfPet,
                command.Color,
                breedId
            );

            await _repository.AddAsync(newPet);
        }
    }
}