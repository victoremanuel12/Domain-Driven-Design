using Microsoft.EntityFrameworkCore;
using Wpm.Clinic.Domain.Entities;
using Wpm.Clinic.Domain.ValueObjects;

public class ClinicDbContext(DbContextOptions<ClinicDbContext> options) : DbContext(options)
{

    public DbSet<Consultation> Consultations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Consultation>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.StartedAt).IsRequired();
            entity.Property(e => e.EndedAt);
            entity.OwnsMany(c => c.AdministrateredDrugs, drug =>
            {
                drug.ToTable("DrugAdministration");
                drug.WithOwner().HasForeignKey("ConsultationId");

                drug.Property<Guid>("Id");
                drug.HasKey("Id");

                drug.Property(e => e.DrugId)
                .HasConversion(v => v.Value,v => (DrugId)v);

                drug.OwnsOne(x => x.Dose, dose =>
                {
                    dose.Property(d => d.Quantity).HasColumnName("DoseQuantity").IsRequired();
                    dose.Property(d => d.Unit).HasColumnName("DoseUnit").IsRequired();
                });

            });
            entity.OwnsMany(v => v.VitalSignsReadings, vitalSigns =>
            {
                vitalSigns.ToTable("VitalSigns");
                vitalSigns.WithOwner().HasForeignKey("ConsultationId");

                vitalSigns.Property<Guid>("Id");
                vitalSigns.HasKey("Id");

                vitalSigns.Property(v => v.Temperature).HasColumnName("Temperature").IsRequired();
                vitalSigns.Property(v => v.HeartRate).HasColumnName("HeartRate").HasPrecision(5, 2).IsRequired();
                vitalSigns.Property(v => v.ReadingDateTime).HasColumnName("ReadingDateTime").IsRequired();
                vitalSigns.Property(v => v.RespirationRate).HasColumnName("RespirationRate").IsRequired();
            });
            entity.OwnsOne(c => c.CurrentWeight, w =>
            {
                w.Property(x => x.Value).HasColumnName("Weight").IsRequired();
            });

            entity.OwnsOne(c => c.Diagnosis, t =>
            {
                t.Property(x => x.Value).HasColumnName("Diagnosis").IsRequired();
            });

            entity.OwnsOne(c => c.Treatment, t =>
            {
                t.Property(x => x.Value).HasColumnName("Treatment").IsRequired();
            });

            entity.Property(e => e.PatiendId)
               .HasConversion( v => v.Value,v => (PatiendId)v);
        });
    }
}
