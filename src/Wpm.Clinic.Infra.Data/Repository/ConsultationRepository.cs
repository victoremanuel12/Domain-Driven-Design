using Microsoft.EntityFrameworkCore;
using Wpm.Clinic.Domain.Entities;
using Wpm.SharedKerbel.Abstract;

namespace Wpm.Clinic.Infra.Data.Repository
{
    public class ConsultationRepository(ClinicDbContext dbContext) : IRepository<Consultation>
    {
        public async Task<Guid> InsertAsync(Consultation consultation)
        {
            dbContext.Consultations.Add(consultation);
            await dbContext.SaveChangesAsync();
            return consultation.Id;
        }
        public async Task<IEnumerable<Consultation>> GetAllAsync() => await dbContext.Consultations.ToListAsync();

        public async Task<Consultation?> GetByIdAsync(Guid id) => await dbContext.Consultations.FirstOrDefaultAsync(e => e.Id == id);


        public async Task UpdateAsync(Consultation consultation)
        {
            dbContext.Consultations.Update(consultation); 
            await dbContext.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var entity = await dbContext.Consultations.FirstOrDefaultAsync(e => e.Id == id);
            dbContext.Consultations.Remove(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }
    }
}
