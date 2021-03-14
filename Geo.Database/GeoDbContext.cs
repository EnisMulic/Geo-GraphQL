using Geo.Core;
using Geo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Geo.Database
{
    public partial class GeoDbContext : DbContext, IGeoDbContext
    {
        public GeoDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Country> Countries { get ; set ; }
        public DbSet<City> Cities { get ; set ; }
        public DbSet<User> Users { get ; set ; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
