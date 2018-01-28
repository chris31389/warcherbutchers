using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WArcherButchers.ServerApp.Controllers
{
    public class ProductController : Controller
    {
        // GET
        public async Task<IActionResult> GetSingle()
        {
            await Task.Delay(1);
            return Ok();
        }
    }
}