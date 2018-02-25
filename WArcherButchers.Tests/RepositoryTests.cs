using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Newtonsoft.Json;
using NUnit.Framework;
using WArcherButchers.ServerApp.Products;

namespace WArcherButchers.Tests
{
    [TestFixture]
    public class RepositoryTests
    {
        private ProductRepository _productRepository;

        [SetUp]
        public void Setup()
        {
            ConventionPack conventionPack = new ConventionPack {new CamelCaseElementNameConvention()};
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            MongoClient mongoClient = new MongoClient("mongodb://localhost:27017/warcher");

            ProductBsonClassMapper productBsonClassMapper = new ProductBsonClassMapper(new VariationBsonClassMapper());
            _productRepository = new ProductRepository(mongoClient, productBsonClassMapper);
        }

        [Test]
        public async Task GetDb()
        {
            IEnumerable<Product> products = await _productRepository.GetAll();

            Console.WriteLine(JsonConvert.SerializeObject(products, Formatting.Indented));
            Assert.That(products, Is.Not.Empty);
        }

        [Test]
        public async Task GetDbSingle()
        {
            Product product = await _productRepository.Get("55a73e85fea4ad03077606f7");

            Console.WriteLine(JsonConvert.SerializeObject(product, Formatting.Indented));
            Assert.That(product, Is.Not.Null);
        }

        [Test]
        public async Task GetRandom()
        {
            Product product1 = await _productRepository.GetRandom();
            Product product2 = await _productRepository.GetRandom();

            Assert.That(product1.Id, Is.Not.EqualTo(product2.Id));
        }
    }
}