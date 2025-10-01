using Wpm.Management.Application.Commands;
using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Events;
using Wpm.Management.Domain.Services.Interfaces;
using Wpm.SharedKerbel.Abstract;

namespace Wpm.Management.Application.Handlers
{
    public class SetWeightCommandHandler : ICommandHandler<SetWeightCommand>
    {
        private readonly IRepository<Pet> _repository;
        private readonly IBreedService _breedService;
        public SetWeightCommandHandler(IRepository<Pet> repository, IBreedService breedService)
        {
            _repository = repository;
            _breedService = breedService;
            DomainEvents.PetWeightUpdated.Subscribe((domainEvent) =>
            {
               // Lógica para lidar com o evento de peso atualizado
                Console.WriteLine($"Peso do pet {domainEvent.Id} atualizado para {domainEvent.Weight} kg.");
            });
        }
        public async Task Handle(SetWeightCommand command)
        {
            var pet = await _repository.GetByIdAsync(command.Id) ?? throw new InvalidOperationException($"Pet {command.Id} não encontrado.");
            pet.SetWeight(command.Weight, _breedService);
            await _repository.UpdateAsync(pet);
        }
    }
}
