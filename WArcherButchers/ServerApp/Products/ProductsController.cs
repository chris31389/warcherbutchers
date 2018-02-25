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
            await Task.Delay(1);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle()
        {
            await Task.Delay(1);
            return Ok();
        }

        [HttpGet("random")]
        public async Task<IActionResult> GetRandom()
        {
            await Task.Delay(1);
            ProductModel product = CreateProductModel();
            return Ok(product);
        }

        private static ProductModel CreateProductModel() => new ProductModel
        {
            Id = "55fd2d300a85b0ff7af2d152",
            Name = "Leicestershire long horn Minced Beef (5kg)",
            Description = "Makes a tasty Chilli!",
            ImageId = "55eed9cf672ed712a1b55048",
            Categories = new []{"Beef", "Bulk"},
            VariationId = "55fd309b0a85b0ff7af2d199",
            PricePerKilo = new Price(5,80),
            Weight = new Weight
            {
                Value = 5,
                Unit = "kg"
            }
        };
    }
}