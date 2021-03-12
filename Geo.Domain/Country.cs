using System;

namespace Geo.Domain
{
    public class Country : IEntity<Guid>
    {
        public Guid Id { get ; set ; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }
}
