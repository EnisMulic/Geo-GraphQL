using HotChocolate;
using HotChocolate.Types;

namespace Geo.GraphQL.Subscriptions
{
    [ExtendObjectType(Name = "Subscription")]
    public class CountrySubscriptions
    {
        [Topic]
        [Subscribe]
        public Domain.Country OnCountryAdded([EventMessage] Domain.Country Country) => Country;
    }
}
