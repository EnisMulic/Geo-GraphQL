using Geo.Contracts.Inputs;
using Geo.Contracts.Payloads;
using Geo.Database;
using Geo.GraphQL.Subscriptions;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using HotChocolate.Types;
using System.Threading;
using System.Threading.Tasks;

namespace Geo.GraphQL.Mutations
{
    [ExtendObjectType(Name = "Mutation")]
    public class CountryMutations
    {
        [UseDbContext(typeof(GeoDbContext))]
        public async Task<AddCountryPayload> AddCountryAsync(
            AddCountryInput input,
            [ScopedService] GeoDbContext context,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken
        )
        {
            var country = new Domain.Country
            {
                Name = input.Name,
                Alpha2Code = input.Alpha2Code
            };

            context.Countries.Add(country);
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(CountrySubscriptions.OnCountryAdded), country, cancellationToken);

            return new AddCountryPayload(country);
        }

        [UseDbContext(typeof(GeoDbContext))]
        public async Task<ResponseMessagePayload> DeleteCountryAsync(DeleteCountryInput input, [ScopedService] GeoDbContext context)
        {
            var country = await context.Countries.FindAsync(input.Id);

            if (country == null)
            {
                return new ResponseMessagePayload("Country not found");
            }

            context.Countries.Remove(country);
            await context.SaveChangesAsync();

            return new ResponseMessagePayload("Country deleted");
        }

        [UseDbContext(typeof(GeoDbContext))]
        public async Task<UpdateCountryPayload> UpdateCountryAsync(UpdateCountryInput input, [ScopedService] GeoDbContext context)
        {
            var country = await context.Countries.FindAsync(input.Id);
            country.Name = input.Name;
            country.Alpha2Code = input.Alpha2Code;
            country.Alpha3Code = input.Alpha3Code;

            await context.SaveChangesAsync();

            return new UpdateCountryPayload(country);
        }
    }
}
