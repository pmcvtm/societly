using System.Collections.Generic;

namespace Societly.Domain
{
    public class Place : Entity
    {
        public int Latitude { get; set; }
        public int Longitude { get; set; }

        public List<Socialite> Residents { get; private set; }
        public List<RawMaterialSource> Resources { get; private set; }

        public void AddResidents(Socialite socialite)
        {
            Residents.Add(socialite);
        }

        public void AddResource(RawMaterialSource source)
        {
            Resources.Add(source);
            source.Location = this;
        }

        public Place()
        {
            Residents = new List<Socialite>();
            Resources = new List<RawMaterialSource>();
        }
    }
}
