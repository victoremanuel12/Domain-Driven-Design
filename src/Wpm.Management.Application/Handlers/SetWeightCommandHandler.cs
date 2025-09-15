using Wpm.Management.Application.Commands;
using Wpm.Management.Domain.Repository.Interfaces;
using Wpm.Management.Domain.Services.Interfaces;

namespace Wpm.Management.Application.Handlers
{
    public class SetWeightCommandHandler(IManagementRepository managementRepository, IBreedService breedService) : ICommandHandler<SetWeightCommand>
    {
        public async Task Handle(SetWeightCommand command)
        {
            var pet = await managementRepository.GetByIdAsync(command.Id);
            if (pet is null)
                throw new InvalidOperationException($"Pet {command.Id} não encontrado.");
            pet.SetWeight(command.Weight, breedService);
            await managementRepository.UpdateAsync(pet);
        }
    }
}
