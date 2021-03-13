using System;
using System.Collections.Generic;

namespace Geo.Domain
{
    public class Country : IEntity<Guid>
    {
        public Guid Id { get ; set ; }
        public string Name { get; set; }
        public string Alpha2Code { get; set; }
        public string Alpha3Code { get; set; }
        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
