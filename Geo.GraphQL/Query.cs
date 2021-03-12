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
        [UseProjection]
        public IQueryable<Domain.Country> GetCountry([ScopedService] GeoDbContext context)
        {
            return context.Countries;
        }

        [UseDbContext(typeof(GeoDbContext))]
        [UseProjection]
        public IQueryable<City> GetCity([ScopedService] GeoDbContext context)
        {
            return context.Cities;
        }
    }
}
