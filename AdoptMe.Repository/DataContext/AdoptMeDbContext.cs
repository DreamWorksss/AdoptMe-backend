using AdoptMe.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace AdoptMe.Repository.DataContext
{
    public class AdoptMeDbContext : DbContext
    {
        public AdoptMeDbContext(DbContextOptions<AdoptMeDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Animal>()
                .Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Shelter>()
                .HasKey(x => x.Id);
            modelBuilder.Entity <Shelter>()
                .Property(x => x.Id).ValueGeneratedOnAdd();
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
    }
}
