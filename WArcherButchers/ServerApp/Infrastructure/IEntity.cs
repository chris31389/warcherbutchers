using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WArcherButchers.ServerApp.Infrastructure
{
    public interface IEntity
    {
        [BsonId]
        ObjectId Id { get; set; }
    }
}