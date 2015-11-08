using System;

namespace Societly.Domain
{
    public class Socialite : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        private GameUser _user;
        public Guid UserId { get; private set; }
        public GameUser User
        {
            get { return _user; }
            set
            {
                _user = value;
                UserId = value.Id;
            }
        }
    }
}
