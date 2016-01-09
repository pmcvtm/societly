using System;

namespace Societly.Domain
{
    public class Socielite : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }
    }
}
