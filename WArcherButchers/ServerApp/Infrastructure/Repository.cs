using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace WArcherButchers.ServerApp.Infrastructure
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        protected abstract string CollectionName { get; }

        private readonly IMongoDatabase _database;

        protected IMongoCollection<TEntity> Collection => _database.GetCollection<TEntity>(CollectionName);

        public Repository(IMongoClient client,
            IBsonClassMapper<TEntity> bsonClassMapper)
        {
            _database = client.GetDatabase("warcher");
            bsonClassMapper.RegisterMap();
        }

        public async Task<TEntity> Get(string id) => await Collection
            .Find(x => x.Id == new ObjectId(id))
            .FirstOrDefaultAsync();

        public async Task<IEnumerable<TEntity>> GetAll() => await Collection
            .Find(new BsonDocument())
            .ToListAsync();

        public async Task<TEntity> Save(TEntity entity)
        {
            await Collection.ReplaceOneAsync(x => x.Id.Equals(entity.Id), entity, new UpdateOptions
            {
                IsUpsert = true
            });

            return entity;
        }

        public async Task Delete(string id) => await Collection.DeleteOneAsync(x => x.Id.Equals(id));

        public async Task Delete(TEntity entity) => await Collection.DeleteOneAsync(x => x.Id.Equals(entity.Id));
    }
}