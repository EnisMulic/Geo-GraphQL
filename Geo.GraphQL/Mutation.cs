using Geo.Database;
using Geo.GraphQL.City;
using Geo.GraphQL.Country;
using HotChocolate;
using HotChocolate.Data;
using System.Threading.Tasks;

namespace Geo.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(GeoDbContext))]
        public async Task<AddCountryPayload> AddCountryAsync(AddCountryInput input, [ScopedService] GeoDbContext context)
        {
            var country = new Domain.Country
            {
                Name = input.Name,
                Abbreviation = input.Abbreviation
            };

            context.Countries.Add(country);
            await context.SaveChangesAsync();

            return new AddCountryPayload(country);
        }

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
