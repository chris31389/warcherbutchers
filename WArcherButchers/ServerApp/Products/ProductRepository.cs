using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WArcherButchers.ServerApp.Infrastructure.Data.Repositories;

namespace WArcherButchers.ServerApp.Products
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Product> GetRandom()
        {
            Product product = await CollectionQuery
                .OrderBy(x => Guid.NewGuid())
                .FirstOrDefaultAsync();

            return product;
        }
    }
}