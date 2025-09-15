using Microsoft.EntityFrameworkCore;
using Wpm.Management.Domain.Entities;
using Wpm.Management.Domain.ValueObjects;
namespace Wpm.Management.Infra.Data
{
    public class ManagementDbContext(DbContextOptions<ManagementDbContext> options) : DbContext(options)
    {
        public DbSet<Pet> Pets { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.OwnsOne(e => e.Weight);
                //Criar o VO em tabela separada
                //entity.OwnsOne(e => e.Weight, prop =>
                //{
                //    prop.ToTable("PetWeights");

                //    // PK
                //    prop.Property<Guid>("Id").ValueGeneratedOnAdd();
                //    prop.HasKey("Id");

                //    // FK para Pet
                //    prop.WithOwner().HasForeignKey("PetId");

                //    // Colunas do VO
                //    prop.Property(w => w.Value)
                //        .HasColumnName("WeightValue")
                //        .IsRequired();
                //});
                entity.Property(e => e.BreedId).HasConversion(v => v.Value, v => BreedId.Create(v));
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Color).HasMaxLength(50);
            });
        }
    }

}
