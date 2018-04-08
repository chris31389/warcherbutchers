using System;

namespace WArcherButchers.ServerApp.Infrastructure.Entities
{
    public abstract class Entity : IEntity
    {
        /// <summary>
        /// The Identifier for the entity.  
        /// This is a property set when creating the entity
        /// </summary>
        public Guid Id { get; protected set; }

        /// <summary>
        /// The last modified date time UTC. 
        /// This is a database generated property and is only updated after saving to a database
        /// </summary>
        public DateTime LastModifiedAtUtc { get; protected set; }

        /// <summary>
        /// The date time UTC of when the entity was created.  
        /// This is a database generated property and is only updated after saving to a database
        /// </summary>
        public DateTime CreatedAtUtc { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
            CreatedAtUtc = SystemClock.UtcNow;
            LastModifiedAtUtc = SystemClock.UtcNow;
        }

        protected void OnModified()
        {
            LastModifiedAtUtc = SystemClock.UtcNow;
        }
    }
}