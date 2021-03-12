using System;

namespace Geo.Domain
{
    public class City : IEntity<Guid>
    {
        public Guid Id { get ; set ; }
        public string Name { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
    }
}
