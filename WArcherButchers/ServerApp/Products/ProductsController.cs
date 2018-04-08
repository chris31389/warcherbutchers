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
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Product> products = await _productRepository.GetAllAsync();
            IEnumerable<ProductModel> productModels = products.SelectMany(Map);
            return Ok(productModels);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetSingle(Guid id)
        {
            Product product = await _productRepository.GetAsync(id);
            List<ProductModel> productModels = Map(product);
            return Ok(productModels[0]);
        }

        [HttpGet("random")]
        public async Task<IActionResult> GetRandom()
        {
            Product product = await _productRepository.GetRandom();
            return Ok(product);
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