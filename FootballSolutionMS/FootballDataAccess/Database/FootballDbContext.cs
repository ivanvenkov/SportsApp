using Microsoft.EntityFrameworkCore;

namespace FootballDataAccess.Database
{
    public class FootballDbContext : DbContext
    {
        public FootballDbContext(DbContextOptions<FootballDbContext> options) : base(options)
        {
        }

        public DbSet<FootballPersonTable> FootballPersons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
