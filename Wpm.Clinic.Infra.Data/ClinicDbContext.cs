using Microsoft.EntityFrameworkCore;
using Wpm.Clinic.Domain.Entities;

namespace Wpm.Clinic.Infra.Data
{
    public class ClinicDbContext(DbContextOptions<ClinicDbContext> options) : DbContext(options)
    {
        public DbSet<Consultation> Consultations { get; set; }
    }
}
