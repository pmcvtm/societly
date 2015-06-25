using System;

namespace Societly.Domain
{
    public class Socialite : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }
    }
}
