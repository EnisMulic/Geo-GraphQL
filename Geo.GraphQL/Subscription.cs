using HotChocolate;
using HotChocolate.Types;

namespace Geo.GraphQL
{
    public class Subscription
    {
        [Topic]
        [Subscribe]
        public Domain.Country OnCountryAdded([EventMessage] Domain.Country Country) => Country;
    }
}
