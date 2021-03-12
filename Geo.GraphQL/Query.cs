using Geo.Database;
using Geo.Domain;
using HotChocolate;
using System.Linq;

namespace Geo.GraphQL
{
    public class Query
    {
        public IQueryable<Country> GetCountry([Service] GeoDbContext context)
        {
            return context.Countries;
        }


    }
}
