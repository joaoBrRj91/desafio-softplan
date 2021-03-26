using System;
namespace SoftPlan.Core.DomainObjects
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public readonly Guid Id;

        public abstract void Validar();
    }
}
