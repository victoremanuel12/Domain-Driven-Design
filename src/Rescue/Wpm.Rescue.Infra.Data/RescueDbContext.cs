using Microsoft.EntityFrameworkCore;
using Wpm.Rescue.Domain.Entities;
namespace Wpm.Rescue.Infra.Data
{
    public class RescueDbContext : DbContext
    {
        public RescueDbContext(DbContextOptions<RescueDbContext> options) : base(options) { }

        public DbSet<Adopter> Adopters { get; set; }
        public DbSet<RescuedAnimal> RescuedAnimals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Adopter>().HasKey(x => x.Id);
            modelBuilder.Entity<Adopter>().OwnsOne(x => x.Name);
            modelBuilder.Entity<Adopter>().OwnsOne(x => x.Questionnaire);
            modelBuilder.Entity<Adopter>().OwnsOne(x => x.Address);
            modelBuilder.Entity<RescuedAnimal>().HasKey(x => x.Id);
            modelBuilder.Entity<RescuedAnimal>().OwnsOne(x => x.AdopterId);
        }
    }
}
