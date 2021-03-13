using Geo.Database;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System.Linq;

namespace Geo.GraphQL.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class CountryQueries
    {
        [UseDbContext(typeof(GeoDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Domain.City> GetCity([ScopedService] GeoDbContext context) => context.Cities;
    }
}
