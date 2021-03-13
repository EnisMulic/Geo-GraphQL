using Geo.Database;
using Geo.Domain;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace Geo.GraphQL.Types
{
    public class CountryType : ObjectType<Country>
    {
        protected override void Configure(IObjectTypeDescriptor<Country> descriptor)
        {
            descriptor.Description("Represents Countries");
            descriptor.Field(i => i.Cities)
                .ResolveWith<Resolvers>(r => r.GetCity(default!, default!))
                .UseDbContext<GeoDbContext>();
        }

        private class Resolvers
        {
            public IQueryable<Domain.City> GetCity(Domain.Country country, [ScopedService] GeoDbContext context)
            {
                return context.Cities.Where(i => i.CountryId == country.Id);
            }
        }
    }
}
