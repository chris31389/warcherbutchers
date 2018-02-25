using MongoDB.Bson.Serialization;
using WArcherButchers.ServerApp.Infrastructure;

namespace WArcherButchers.ServerApp.Products
{
    public class ProductBsonClassMapper : BsonClassMapper<Product>
    {
        public ProductBsonClassMapper(IBsonClassMapper<Variation> variationBsonClassMapper)
        {
            variationBsonClassMapper.RegisterMap();
        }

        protected override void ClassMapInitializer(
            BsonClassMap<Product> bsonClassMap)
        {
            bsonClassMap.AutoMap();
            bsonClassMap.SetIgnoreExtraElements(true);
        }
    }
}