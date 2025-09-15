using Microsoft.EntityFrameworkCore;
using Wpm.Clinic.Domain.Entities;

public class ClinicDbContext : DbContext
{
    public ClinicDbContext(DbContextOptions<ClinicDbContext> options) : base(options) { }

    public DbSet<Consultation> Consultations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consultation>(entity =>
        {
            entity.HasKey(e => e.Id);

      

        });
    }
}
