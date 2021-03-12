using Geo.Database;
using HotChocolate;
using HotChocolate.Types;
using System.Linq;

namespace Geo.GraphQL.City
{
    public class CityType : ObjectType<Domain.City>
    {
        protected override void Configure(IObjectTypeDescriptor<Domain.City> descriptor)
        {
            descriptor.Description("Represents Cities");
            descriptor.Field(i => i.Country)
                .ResolveWith<Resolvers>(r => r.GetCountry(default!, default!))
                .UseDbContext<GeoDbContext>();
        }

        private class Resolvers
        {
            public Domain.Country GetCountry(Domain.City city, [ScopedService] GeoDbContext context)
            {
                return context.Countries.SingleOrDefault(i => i.Id == city.CountryId);
            }
        }
    }
}
