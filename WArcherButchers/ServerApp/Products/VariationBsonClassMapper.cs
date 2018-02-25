using MongoDB.Bson.Serialization;
using WArcherButchers.ServerApp.Infrastructure;

namespace WArcherButchers.ServerApp.Products
{
    public class VariationBsonClassMapper : BsonClassMapper<Variation>
    {
        protected override void ClassMapInitializer(
            BsonClassMap<Variation> bsonClassMap)
        {
            bsonClassMap.AutoMap();
            bsonClassMap.SetIgnoreExtraElements(true);
        }
    }
}