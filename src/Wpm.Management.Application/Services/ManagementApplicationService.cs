using Wpm.Management.Application.Commands;
using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Services.Interfaces;
using Wpm.Management.Domain.ValueObjects;
using Wpm.SharedKerbel.Abstract;

namespace Wpm.Management.Application.Services
{
    public class ManagementApplicationService(IBreedService breedService, IRepository<Pet> repository)
    {


        public async Task Handle(CreatePetCommand command)
        {
            var breedId = new BreedId(command.Id, breedService);
            var newPet = new Pet(
                              command.Id,
                              command.Name,
                              command.Age,
                              command.SexOfPet,
                              command.Color,
                              breedId
                              );
            await repository.InsertAsync(newPet);
        }
    }
}
