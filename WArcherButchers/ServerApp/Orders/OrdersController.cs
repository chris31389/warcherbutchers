using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WArcherButchers.Infrastructure;
using WArcherButchers.Infrastructure.Settings;
using WArcherButchers.ServerApp.PaymentSense;

namespace WArcherButchers.ServerApp.Orders
{
    [Route("api/v1/[controller]")]
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
            Price price = await CalculateTotal(createOrderDto.OrderSelections);
            OrderDto orderDto =
                await CreateOrderAsync(createOrderDto.CustomerData, createOrderDto.OrderSelections, price);
            string callbackUrl = createOrderDto.CallbackUrl.Replace("{orderId}", orderDto.Id.ToString());
            IEnumerable<FormElementDto> formDetails = GetFormDetails(orderDto.Id, callbackUrl)
                .Select(x => new FormElementDto
                {
                    Key = x.Key,
                    Value = x.Value
                });
            CreateOrderOutDto createOrderOutDto = new CreateOrderOutDto
            {
                Order = orderDto,
                FormDetails = formDetails
            };
            return Ok(createOrderOutDto);
        }

        private async Task<OrderDto> CreateOrderAsync(CustomerDataDto createOrderDto,
            IEnumerable<OrderSelectionDto> orderSelection, Price price)
        {
            await Task.Delay(1);
            OrderDto orderDto = new OrderDto();
            orderDto.Id = Guid.NewGuid();
            return orderDto;
        }

        private async Task<Price> CalculateTotal(IEnumerable<OrderSelectionDto> productSelection)
        {
            await Task.Delay(1);
            Price totalCost = new Price(15, 30);
            return totalCost;
        }

        private Dictionary<string, object> GetFormDetails(
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
            return formData;
        }
    }
}