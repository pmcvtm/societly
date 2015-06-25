using System;

namespace Societly.Domain
{
    public abstract class Entity
    {
        public Guid Id { get; private set; }
        public Entity() { Id = Guid.NewGuid(); }
    }
}
