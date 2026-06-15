using Microsoft.EntityFrameworkCore;
using Wpm.Management.Domain.Repositories;
using Wpm.Management.Domain.ValueObjects;

namespace Wpm.Management.Infra.Data.Repository
{
    public class PetRepository : IPetRepository
    {
        private readonly ManagementDbContext _db;

        public PetRepository(ManagementDbContext db)
        {
            _db = db;
        }

        public async Task<Pet?> GetByIdAsync(PetId id)
        {
            return await _db.Pets.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Pet pet)
        {
            await _db.Pets.AddAsync(pet);
        }

        public async Task RemoveAsync(Pet pet)
        {
            _db.Pets.Remove(pet);
        }
        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
