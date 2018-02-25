using MongoDB.Bson.Serialization;

namespace WArcherButchers.ServerApp.Infrastructure
{
    public abstract class BsonClassMapper<TEntity> : IBsonClassMapper<TEntity>
        where TEntity : IEntity
    {
        public void RegisterMap()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(TEntity)))
                BsonClassMap.RegisterClassMap<TEntity>(ClassMapInitializer);
        }

        protected abstract void ClassMapInitializer(BsonClassMap<TEntity> bsonClassMap);
    }
}