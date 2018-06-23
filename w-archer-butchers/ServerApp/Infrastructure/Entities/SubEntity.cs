using System;

namespace WArcherButchers.ServerApp.Infrastructure.Entities
{
    public abstract class SubEntity : Entity, ISubEntity
    {
        protected SubEntity(Guid entityId)
        {
            EntityId = entityId;
        }

        protected SubEntity()
        {
        }
        
        public Guid EntityId { get; protected set; }
    }
}