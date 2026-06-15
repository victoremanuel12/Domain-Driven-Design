using Wpm.Management.Application.Commands;
using Wpm.Management.Domain.Repositories;
using Wpm.Management.Domain.ValueObjects;
using Wpm.SharedKerbel.Abstract;
using Wpm.SharedKerbel.IntegrationEvent.Wpm.SharedKernel.Messaging;

namespace Wpm.Management.Application.Handlers
{
    public class AdoptCommandHandler : ICommandHandler<AdoptPetCommand>
    {
        private readonly IPetRepository _repository;
        private readonly IIntegrationEventPublisher _integrationEventPublisher;
        public AdoptCommandHandler(IPetRepository repository, IIntegrationEventPublisher publisher)
        {
            _repository = repository;
            _integrationEventPublisher = publisher;
        }
        public async Task Handle(AdoptPetCommand command)
        {
            var petId = PetId.Create(command.Id);
            var pet = await _repository.GetByIdAsync(petId);
            if (pet == null) throw new Exception($"Pet with id {command.Id} not found.");
            pet.Adopt();
        }
    }
}
