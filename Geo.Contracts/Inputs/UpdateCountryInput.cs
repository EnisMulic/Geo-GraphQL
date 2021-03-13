using System;

namespace Geo.Contracts.Inputs
{
    public record UpdateCountryInput(Guid Id, string Name, string Alpha2Code, string Alpha3Code);
}
