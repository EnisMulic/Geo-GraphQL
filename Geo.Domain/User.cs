using System;

namespace Geo.Domain
{
    public class User : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Salt { get; set; }
        public string Hash { get; set; }
    }
}
