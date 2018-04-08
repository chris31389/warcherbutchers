using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WArcherButchers.ServerApp.Infrastructure;

namespace WArcherButchers.ServerApp.Products
{
    [Route("api/v1/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IRepository<Product> _productRepository;

        public ProductsController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Product> products = await _productRepository.GetAll();
            IEnumerable<ProductModel> productModels = products.SelectMany(Map);
            return Ok(productModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(string id)
        {
            Product product = await _productRepository.Get(id);
            List<ProductModel> productModels = Map(product);
            return Ok(productModels[0]);
        }

        [HttpGet("random")]
        public async Task<IActionResult> GetRandom()
        {
            IEnumerable<Product> products = await _productRepository.GetAll();
            List<ProductModel> productModels = products.SelectMany(Map).ToList();
            Random random = new Random();
            int randomId = random.Next(productModels.Count);
            return Ok(productModels[randomId]);
        }

        private static List<ProductModel> Map(Product product) => product.Variations
            .Select(variation =>
            {
                string variationName = !string.IsNullOrWhiteSpace(variation.Name)
                    ? variation.Name
                    : variation.Weight.Value.ToString() + variation.Weight.Unit.ToString();
                return new ProductModel
                {
                    Id = product.Id.ToString(),
                    Categories = product.Categories,
                    Description = product.Description,
                    DetailedDescription = product.DetailedDescription,
                    ImageId = variation.ImageId,
                    ImageUrl = variation.ImageUrl,
                    IsSpeciality = product.Speciality,
                    Name = $"{product.Name} ({variationName})",
                    Price = variation.Price,
                    PricePerKilo = PricePerKiloHelper.CalculatePrice(variation.Weight, variation.Price),
                    Weight = variation.Weight,
                    VariationId = variation.Id.ToString()
                };
            }).ToList();
    }
}