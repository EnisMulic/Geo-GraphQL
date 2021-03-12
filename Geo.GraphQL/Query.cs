using Geo.Database;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace Geo.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(GeoDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Domain.Country> GetCountry([ScopedService] GeoDbContext context)
        {
            return context.Countries;
        }

        [UseDbContext(typeof(GeoDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Domain.City> GetCity([ScopedService] GeoDbContext context)
        {
            return context.Cities;
        }
    }
}
