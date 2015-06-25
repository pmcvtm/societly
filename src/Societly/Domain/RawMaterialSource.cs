using System;

namespace Societly.Domain
{
    public class RawMaterialSource : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }

        private RawMaterial _material;
        public Guid MaterialId { get; private set; }
        public RawMaterial Material
        {
            get { return _material; }
            set
            {
                _material = value;
                MaterialId = value.Id;
            }
        }

        private Place _location;
        public Guid LocationId { get; private set; }
        public Place Location
        {
            get { return _location; }
            set
            {
                _location = value;
                LocationId = value.Id;
            }
        }
    }
}
