using Geo.Domain;
using Microsoft.EntityFrameworkCore;

namespace Geo.Core
{
    public interface IGeoDbContext
    {
        DbSet<City> Cities { get; set; }
        DbSet<Country> Countries { get; set; }
        DbSet<User> Users { get; set; }
    }
}
