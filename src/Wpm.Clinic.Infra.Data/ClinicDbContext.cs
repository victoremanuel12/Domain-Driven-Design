using Microsoft.EntityFrameworkCore;
using Wpm.Clinic.Domain.Entities;
using Wpm.Clinic.Domain.ValueObjects;

public class ClinicDbContext(DbContextOptions<ClinicDbContext> options) : DbContext(options)
{

    public DbSet<Consultation> Consultations { get; set; }
    public DbSet<VitalSigns> VitalSigns { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
