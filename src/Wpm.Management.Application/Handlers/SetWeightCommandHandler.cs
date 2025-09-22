using Wpm.Management.Application.Commands;
using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Services.Interfaces;
using Wpm.SharedKerbel.Abstract;
using Wpm.SharedKerbel.CommandHandler;

namespace Wpm.Management.Application.Handlers
{
    public class SetWeightCommandHandler(IRepository<Pet> repository, IBreedService breedService) : ICommandHandler<SetWeightCommand>
    {
        public async Task Handle(SetWeightCommand command)
        {
            var pet = await repository.GetByIdAsync(command.Id) ?? throw new InvalidOperationException($"Pet {command.Id} não encontrado.");
            pet.SetWeight(command.Weight, breedService);
            await repository.UpdateAsync(pet);
        }
    }
}
