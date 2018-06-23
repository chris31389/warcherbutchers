using System;
using System.Runtime.Serialization;
using WArcherButchers.ServerApp.Infrastructure.Entities;

namespace WArcherButchers.ServerApp.Infrastructure.Data.Exceptions
{
    [Serializable]
    public class EntityIdDoesNotMatchPersistenceEntityIdException<T> : Exception
        where T : IEntity
    {
        public EntityIdDoesNotMatchPersistenceEntityIdException()
        {
        }

        public EntityIdDoesNotMatchPersistenceEntityIdException(Guid entityId, Guid persistenceEntityId) : base(
            $"{entityId} does not match {persistenceEntityId} for type {typeof(T)}")
        {
        }

        public EntityIdDoesNotMatchPersistenceEntityIdException(string message) : base(message)
        {
        }

        public EntityIdDoesNotMatchPersistenceEntityIdException(string message, Exception inner) : base(message, inner)
        {
        }

        protected EntityIdDoesNotMatchPersistenceEntityIdException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}