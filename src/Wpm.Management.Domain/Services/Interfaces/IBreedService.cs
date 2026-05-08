using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Services.Interfaces
{
    public interface IBreedService
    {
        Breed? GetBreed(BreedId id);
    }
}
