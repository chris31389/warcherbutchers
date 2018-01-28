using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WArcherButchers.Infrastructure.Settings;
using WArcherButchers.ServerApp.PaymentSense;

namespace WArcherButchers.ServerApp.Orders
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly string _serverUrl;

        public OrdersController(IOptions<ServerSettings> serverSettings)
        {
            _serverUrl = serverSettings.Value.Url;
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto createOrderDto)
        {
            await Task.Delay(1);
            return Ok(createOrderDto);
        }

        [HttpGet("{orderId:guid}/form")]
        public async Task<IActionResult> GetFormDetails(
            Guid orderId,
            string callbackUrl)
        {
            Dictionary<string, object> formValues = new Dictionary<string, object>
            {
                {"MerchantID", "Test-2994724"},
                {"Amount", 100},
                {"CurrencyCode", 826},
                {"TransactionType", "SALE"},
                {"PaymentProcessorDomain", "paymentsensegateway.com"},
                {"HashMethod", "SHA1"},
                {"ResultDeliveryMethod", "POST"},
                {"CurrencyCode", 826},
                {"OrderDescription", "Sale of Chilled Meat Products"},
                {"CV2Mandatory", true},
                {"Address1Mandatory", true},
                {"CityMandatory", true},
                {"PostCodeMandatory", true},
                {"StateMandatory", true},
                {"CountryMandatory", true},
                {"PaymentFormDisplaysResult", false},
                {"AVSOverridePolicy", "EFFF"},
                {"CV2OverridePolicy", "FF"},
                {"ServerResultURL", $"{_serverUrl}/confirmpayment"},
                {"OrderID", orderId.ToString()},
                {"CallbackURL", callbackUrl}
            };
            string stringToHash = HashDigestFactory.GetStringToHash(formValues,
                "WwUbLs5oGMQqZVVHvw4XgxMefcWE2TXfW5zEUP/tzIqf+iBm5iUn85+sBkTeK3NFfrjVmzRHqTkR91oOesJR",
                "1q2aW3zSe4");
            Dictionary<string,
                object> formData = formValues.ToDictionary(x => x.Key, x => x.Value);
            formData.Add("HashDigest",
                stringToHash);
            return Ok();
        }
    }
}