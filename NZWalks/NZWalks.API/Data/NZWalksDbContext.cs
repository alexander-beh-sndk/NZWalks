using Microsoft.EntityFrameworkCore;

namespace NZWalks.API.Data
{
    public class NZWalksDbContext : DbContext
    {
        public NZWalksDbContext(DbContextOptions<NZWalksDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Models.Domain.Difficulty> Difficulties { get; set; }
        public DbSet<Models.Domain.Region> Regions { get; set; }
        public DbSet<Models.Domain.Walk> Walks { get; set; }
    }
}
