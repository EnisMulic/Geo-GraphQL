using Geo.Contracts.Inputs;
using Geo.Contracts.Payloads;
using Geo.Database;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Types;
using System.Threading.Tasks;

namespace Geo.GraphQL.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class CityMutations
    {
        [UseDbContext(typeof(GeoDbContext))]
        public async Task<AddCityPayload> AddCityAsync(AddCityInput input, [ScopedService] GeoDbContext context)
        {
            var city = new Domain.City
            {
                Name = input.Name,
                CountryId = input.CountryId
            };

            context.Cities.Add(city);
            await context.SaveChangesAsync();

            return new AddCityPayload(city);
        }
    }
}
