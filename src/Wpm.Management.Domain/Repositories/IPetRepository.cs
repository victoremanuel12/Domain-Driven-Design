namespace Wpm.Management.Domain.Repositories
{
    public interface IPetRepository
    {
        Task<Pet?> GetByIdAsync(Guid id);
        Task AddAsync(Pet pet);
        Task RemoveAsync(Pet pet);
    }
}
