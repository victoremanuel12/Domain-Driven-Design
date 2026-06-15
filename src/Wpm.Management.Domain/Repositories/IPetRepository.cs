using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Domain.Repositories
{
    public interface IPetRepository
    {
        Task<Pet?> GetByIdAsync(PetId id);
        Task AddAsync(Pet pet);
        Task RemoveAsync(Pet pet);
        Task SaveChangesAsync();
    }
}
