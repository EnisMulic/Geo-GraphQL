using System;

namespace Geo.GraphQL.City
{
    public record AddCityInput(string Name, Guid CountryId);
}
