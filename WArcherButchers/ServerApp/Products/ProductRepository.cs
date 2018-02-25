using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using WArcherButchers.ServerApp.Infrastructure;

namespace WArcherButchers.ServerApp.Products
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(
            IMongoClient client,
            IBsonClassMapper<Product> bsonClassMapper
        ) : base(client, bsonClassMapper)
        {
        }

        protected override string CollectionName => "products";

        public async Task<Product> GetRandom()
        {
            IEnumerable<Product> products = await GetAll();
            Product product = products
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefault();

            return product;
        }
    }
}