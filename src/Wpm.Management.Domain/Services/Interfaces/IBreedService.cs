using Wpm.Management.Domain.Entities;

namespace Wpm.Management.Domain.Services.Interfaces
{
    public interface IBreedService
    {
        Breed? GetBreed(Guid id);
    }
}
