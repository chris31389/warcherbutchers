using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WArcherButchers.ServerApp.Products
{
    [Route("api/v1/[controller]")]
    public class ProductsController : Controller
    {
        [HttpGet("")]
        public async Task<IActionResult> GetSingle()
        {
            await Task.Delay(1);
            return Ok();
        }
    }
}