using System.Collections.Generic;

namespace Societly.Domain
{
    public class Place : Entity
    {
        public int Latitude { get; set; }
        public int Longitude { get; set; }

        public List<Socielite> Residents { get; private set; }
        public List<RawMaterialSource> Resources { get; private set; }

        public void AddResidents(Socielite socielite)
        {
            Residents.Add(socielite);
        }

        public void AddResource(RawMaterialSource source)
        {
            Resources.Add(source);
            source.Location = this;
        }

        public Place()
        {
            Residents = new List<Socielite>();
            Resources = new List<RawMaterialSource>();
        }
    }
}
