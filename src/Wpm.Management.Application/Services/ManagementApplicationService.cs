using Wpm.Management.Application.Commands;
using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.Repository.Interfaces;
using Wpm.Management.Domain.Services.Interfaces;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Application.Services
{
    public class ManagementApplicationService(IBreedService breedService, IManagementRepository managementRepository)
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
            await managementRepository.InsertAsync(newPet);
        }
    }
}
