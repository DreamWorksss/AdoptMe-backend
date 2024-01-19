using AdoptMe.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace AdoptMe.Repository.DataContext
{
    public class AdoptMeDbContext : DbContext
    {
        public AdoptMeDbContext(DbContextOptions<AdoptMeDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Pet>()
                .Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Shelter>()
                .HasKey(x => x.Id);
            modelBuilder.Entity <Shelter>()
                .Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Donation>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Donation>()
                .Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<AdoptionRequest>()
                .HasKey(x =>x.Id);
            modelBuilder.Entity<AdoptionRequest>()
                .Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<AdoptionAtDistance>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<AdoptionAtDistance>()
                .Property(x => x.Id).ValueGeneratedOnAdd();
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<AdoptionAtDistance> AdoptionsAtDistance { get; set; }
        public DbSet<AdoptionRequest> AdoptionRequests { get; set; }   
    }
}
