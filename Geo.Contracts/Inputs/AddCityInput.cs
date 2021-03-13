using System;

namespace Geo.Contracts.Inputs
{
    public record AddCityInput(string Name, Guid CountryId);
}
