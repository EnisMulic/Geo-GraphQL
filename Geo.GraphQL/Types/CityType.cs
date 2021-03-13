using Geo.Database;
using Geo.Domain;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace Geo.GraphQL.Types
{
    public class CityType : ObjectType<City>
    {
        protected override void Configure(IObjectTypeDescriptor<City> descriptor)
        {
            descriptor.Description("Represents Cities");
            descriptor.Field(i => i.Country)
                .ResolveWith<Resolvers>(r => r.GetCountry(default!, default!))
                .UseDbContext<GeoDbContext>();
        }

        private class Resolvers
        {
            public Country GetCountry(City city, [ScopedService] GeoDbContext context)
            {
                return context.Countries.SingleOrDefault(i => i.Id == city.CountryId);
            }
        }
    }
}
