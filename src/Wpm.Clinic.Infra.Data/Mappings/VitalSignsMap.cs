using Wpm.Clinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Wpm.Clinic.Infra.Data.Mappings
{

    public class VitalSignsMap : IEntityTypeConfiguration<VitalSigns>
    {
        public void Configure(EntityTypeBuilder<VitalSigns> entity)
        {
            entity.ToTable("VitalSigns");
            entity.HasKey(e => e.Id);
            entity.Property(v => v.ConsultationId).IsRequired();
            entity.Property(v => v.Temperature).HasColumnName("Temperature").IsRequired();
            entity.Property(v => v.HeartRate).HasColumnName("HeartRate").HasPrecision(5, 2).IsRequired();
            entity.Property(v => v.ReadingDateTime).HasColumnName("ReadingDateTime").IsRequired();
            entity.Property(v => v.RespirationRate).HasColumnName("RespirationRate").IsRequired();
        }
    }
}
