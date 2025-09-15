
using Wpm.Management.Domain.Entities;

namespace Wpm.Management.Application.Commands
{
    public record CreatePetCommand(Guid Id, string Name, string Color, int Age, SexOfPet SexOfPet, Guid BreedId);

}
