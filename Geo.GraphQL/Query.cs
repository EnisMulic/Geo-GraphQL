using Geo.Database;
using Geo.Domain;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace Geo.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(GeoDbContext))]
        public IQueryable<Country> GetCountry([ScopedService] GeoDbContext context)
        {
            return context.Countries;
        }
    }
}
