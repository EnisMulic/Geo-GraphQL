using Geo.Core;
using Geo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Geo.Database
{
    public class GeoDbContext : DbContext, IGeoDbContext
    {
        public GeoDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Country> Countries { get ; set ; }
        public DbSet<City> Cities { get ; set ; }
    }
}
