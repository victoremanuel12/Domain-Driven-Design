using Microsoft.EntityFrameworkCore;
using Wpm.Management.Domain.Entities;
using Wpm.SharedKerbel.Abstract;

namespace Wpm.Management.Infra.Data.Repository;

public class ManagementRepository(ManagementDbContext dbContext) : IRepository<Pet>
{

    public async Task<Pet?> GetByIdAsync(Guid id)
        => await dbContext.Pets.FirstOrDefaultAsync(p => p.Id == id);

    public async Task<IEnumerable<Pet>> GetAllAsync()
        => await dbContext.Pets.ToListAsync();

    public async Task<Guid> InsertAsync(Pet pet)
    {
        await dbContext.Pets.AddAsync(pet);
        await SaveChangesAsync();
        return pet.Id;
    }

    public async Task UpdateAsync(Pet pet)
    {
        dbContext.Pets.Update(pet);
        await SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var pet = await dbContext.Pets.FirstOrDefaultAsync(p => p.Id == id);
        if (pet != null)
        {
            dbContext.Pets.Remove(pet);
            await SaveChangesAsync();
        }
    }

    public async Task SaveChangesAsync()
    {
        await dbContext.SaveChangesAsync();
    }
}
