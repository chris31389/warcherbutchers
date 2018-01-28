using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WArcherButchers.ServerApp.PaymentSense;

namespace WArcherButchers.ServerApp.Orders
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto createOrderDto)
        {
            await Task.Delay(1);
            return Ok(createOrderDto);
        }

        [HttpGet("{orderId:guid}/form")]
        public async Task<IActionResult> GetFormDetails(Guid orderId)
        {
            Dictionary<string, object> formValues = new Dictionary<string, object>
            {
                {"MerchantID", "Test-2994724"},
                {"Amount", 100},
            };
            string stringToHash = HashDigestFactory.GetStringToHash(formValues,
                "WwUbLs5oGMQqZVVHvw4XgxMefcWE2TXfW5zEUP/tzIqf+iBm5iUn85+sBkTeK3NFfrjVmzRHqTkR91oOesJR", "1q2aW3zSe4");
            Dictionary<string, object> formData = formValues.ToDictionary(x => x.Key, x => x.Value);
            formData.Add("HashDigest", stringToHash);
            return Ok();
        }
    }
}