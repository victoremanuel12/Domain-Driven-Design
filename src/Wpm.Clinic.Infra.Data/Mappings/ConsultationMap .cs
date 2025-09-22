namespace Wpm.Clinic.Infra.Data.Mappings
{
    using global::Wpm.Clinic.Domain.Entities;
    using global::Wpm.Clinic.Domain.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    namespace Wpm.Clinic.Infra.Data.Mappings
    {
        public class ConsultationMap : IEntityTypeConfiguration<Consultation>
        {
            public void Configure(EntityTypeBuilder<Consultation> entity)
            {
                entity.HasKey(e => e.Id);

                
                entity.OwnsOne(d => d.DateTimeRange, w =>
                {
                    w.Property(x => x.StartedAt).HasColumnName("StartedAt").IsRequired();
                    w.Property(x => x.EndedAt).HasColumnName("EndedAt");
                    w.Property(x => x.Duration).HasColumnName("Duration");
                });

                entity.OwnsMany(c => c.AdministrateredDrugs, drug =>
                {
                    drug.ToTable("DrugAdministration");
                    drug.WithOwner().HasForeignKey("ConsultationId");

                    drug.Property<Guid>("Id");
                    drug.HasKey("Id");

                    drug.Property(e => e.DrugId)
                        .HasConversion(v => v.Value, v => (DrugId)v);

                    drug.OwnsOne(x => x.Dose, dose =>
                    {
                        dose.Property(d => d.Quantity).HasColumnName("DoseQuantity").IsRequired();
                        dose.Property(d => d.Unit).HasColumnName("DoseUnit").IsRequired();
                    });
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
                    .HasConversion(v => v.Value, v => (PatiendId)v);

                entity.HasMany(c => c.VitalSignsReadings)
                    .WithOne(v => v.Consultation)
                    .HasForeignKey(v => v.ConsultationId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.Navigation(c => c.VitalSignsReadings)
                        .UsePropertyAccessMode(PropertyAccessMode.Field);
            }
        }
    }
}
