using Wpm.Management.Application.Commands;
using Wpm.Management.Domain.Events;
using Wpm.Management.Domain.Repositories;
using Wpm.Management.Domain.Services.Interfaces;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Application.Services
{
    public class ManagementApplicationService
    {
        private readonly IBreedService _breedService;
        private readonly IPetRepository _repository;

        public ManagementApplicationService(
            IBreedService breedService,
            IPetRepository repository)
        {
            _breedService = breedService;
            _repository = repository;

            DomainEvents.PetCreated.Subscribe((domainEvent) =>
            {
                // aqui eu coloco o integrationEvent
                
            });
        }

        public async Task Handle(CreatePetCommand command)
        {
            var breedId = new BreedId(command.Id, _breedService);

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