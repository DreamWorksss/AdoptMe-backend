using AdoptMe.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace AdoptMe.Repository.DataContext
{
    public class AdoptMeDbContext : DbContext
    {
        public AdoptMeDbContext(DbContextOptions<AdoptMeDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Animal> Animals { get; set; }
    }
}
