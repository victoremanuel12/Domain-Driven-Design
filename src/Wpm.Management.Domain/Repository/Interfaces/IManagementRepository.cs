using Wpm.Management.Domain.Entities;

namespace Wpm.Management.Domain.Repository.Interfaces
{
    public interface IManagementRepository
    {
        Task<Pet?> GetByIdAsync(Guid id);
        Task<IEnumerable<Pet>> GetAllAsync();
        Task InsertAsync(Pet pet);
        Task UpdateAsync(Pet pet);
        Task DeleteAsync(Guid id);

    }
}
