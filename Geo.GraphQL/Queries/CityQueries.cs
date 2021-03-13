using Geo.Database;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System.Linq;

namespace Geo.GraphQL.Queries
{
    [ExtendObjectType(Name = "Query")]
    public class CityQueries
    {
        [UseDbContext(typeof(GeoDbContext))]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Domain.Country> GetCountry([ScopedService] GeoDbContext context) => context.Countries;
    }
}
