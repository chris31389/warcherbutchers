using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using WArcherButchers.ServerApp.Products;
using WArcherButchers.Tests.ServerApp.Infrastructure;

namespace WArcherButchers.Tests.ServerApp.Products
{
    public class ProductRepositoryTests : WArcherDbTests
    {
        [Test]
        public async Task GivenProduct_WhenISave_ThenItSaves()
        {
            Product product = new Product();

            using (DbContext dbContext = GetDbContext())
            {
                ProductRepository productRepository = new ProductRepository(dbContext);
                await productRepository.SaveAsync(product);
            }

            using (DbContext dbContext = GetDbContext())
            {
                int count = await dbContext.Set<Product>().CountAsync();
                Assert.That(count, Is.EqualTo(1));
            }
        } 

        [Test]
        public async Task GivenProductWithAVariation_WhenISave_ThenItSavesVariation()
        {
            Product product = new Product();
            product.AddVariation(new VariationDto());

            using (DbContext dbContext = GetDbContext())
            {
                ProductRepository productRepository = new ProductRepository(dbContext);
                await productRepository.SaveAsync(product);
            }

            using (DbContext dbContext = GetDbContext())
            {
                int count = await dbContext.Set<Variation>().CountAsync();
                Assert.That(count, Is.EqualTo(1));
            }
        }

        [Test]
        public async Task GivenProductWithAVariationWithAWeight_WhenISave_ThenItSavesWeight()
        {
            Product product = new Product();
            product.AddVariation(new VariationDto
            {
                WeightUnit = "kg",
                WeightValue = 1
            });

            using (DbContext dbContext = GetDbContext())
            {
                ProductRepository productRepository = new ProductRepository(dbContext);
                await productRepository.SaveAsync(product);
            }

            using (DbContext dbContext = GetDbContext())
            {
                int count = await dbContext.Set<Weight>().CountAsync();
                Assert.That(count, Is.EqualTo(1));
            }
        } 
    }
}