using Microsoft.EntityFrameworkCore;
using Wpm.Clinic.Domain.Entities;

public class ClinicDbContext(DbContextOptions<ClinicDbContext> options) : DbContext(options)
{

    public DbSet<Consultation> Consultations { get; set; }
    public DbSet<VitalSigns> VitalSigns { get; set; }
    public DbSet<ConsultationEventData> ConsultationEvent { get; set; }


    public record ConsultationEventData(Guid Id, string AggregateName, string EventName, string Data, string AssemblyQualifiedName);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
