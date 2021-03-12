using System;
using System.Collections.Generic;

namespace Geo.Domain
{
    public class Country : IEntity<Guid>
    {
        public Guid Id { get ; set ; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
