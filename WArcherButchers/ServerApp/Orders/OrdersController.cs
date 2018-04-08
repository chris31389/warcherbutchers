using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WArcherButchers.Infrastructure.Settings;
using WArcherButchers.ServerApp.Infrastructure;
using WArcherButchers.ServerApp.PaymentSense;

namespace WArcherButchers.ServerApp.Orders
{
    [Route("api/v1/[controller]")]
    public class OrdersController : Controller
    {
        private readonly string _serverUrl;
        private readonly HashDigestFactory _hashDigestFactory;

        public OrdersController(IOptions<ServerSettings> serverSettings)
        {
            _serverUrl = serverSettings.Value.Url;
            _hashDigestFactory = new HashDigestFactory();
        }

        [HttpPost("")]
        public async Task<IActionResult> Create([FromBody] CreateOrderModel createOrderModel)
        {
            OrderModel orderModel =
                await CreateOrderAsync(createOrderModel);
            string callbackUrl = createOrderModel.CallbackUrl.Replace("{orderId}", orderModel.Id.ToString());
            IEnumerable<FormElementModel> formDetails = GetFormDetails(orderModel, createOrderModel.CustomerData, callbackUrl)
                .Select(x => new FormElementModel
                {
                    Key = x.Key,
                    Value = x.Value
                });
            
            return Ok(formDetails);
        }

        private static async Task<OrderModel> CreateOrderAsync(CreateOrderModel createOrderModel)
        {
            Price price = await CalculateTotal(createOrderModel.OrderSelections);
            OrderModel orderModel = new OrderModel
            {
                Id = Guid.NewGuid(),
                Price = price
            };
            return orderModel;
        }

        private static async Task<Price> CalculateTotal(IEnumerable<OrderSelectionModel> productSelection)
        {
            await Task.Delay(1);
            Price totalCost = new Price(1530);
            return totalCost;
        }

        private Dictionary<string, object> GetFormDetails(OrderModel order,
            CustomerDataModel customerData,
            string callbackUrl)
        {
            Dictionary<string, object> formValues = new Dictionary<string, object>
            {
                {"MerchantID", "Test-2994724"},
                {"Amount", order.Price.ToInt()},
                {"CurrencyCode", 826},
                {"EchoAVSCheckResult", false},
                {"EchoCV2CheckResult", false},
                {"EchoThreeDSecureAuthenticationCheckResult", false},
                {"EchoCardType", false},
                {"AVSOverridePolicy", "EFFF"},
                {"CV2OverridePolicy", "FF"},
                {"ThreeDSecureOverridePolicy", false},
                {"OrderID", order.Id.ToString()},
                {"TransactionType", "SALE"},
                {"TransactionDateTime", DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss zzz")},
                {"CallbackURL", callbackUrl},
                {"OrderDescription", "Sale of Chilled Meat Products"},
                {"CustomerName", customerData.Name},
                {"Address1", ""},
                {"Address2", ""},
                {"Address3", ""},
                {"Address4", ""},
                {"City", ""},
                {"State", ""},
                {"PostCode", ""},
                {"CountryCode", ""},
                {"EmailAddress", customerData.EmailAddress},
                {"PhoneNumber", customerData.PhoneNumber},
                {"EmailAddressEditable", false},
                {"PhoneNumberEditable", false},
                {"CV2Mandatory", true},
                {"Address1Mandatory", true},
                {"CityMandatory", true},
                {"PostCodeMandatory", true},
                {"StateMandatory", true},
                {"CountryMandatory", true},
                {"ResultDeliveryMethod", "SERVER"},
                {"ServerResultURL", $"{_serverUrl}/api/v1/confirm-payment"},
                {"PaymentFormDisplaysResult", false}
            };
            string stringToHash = _hashDigestFactory.Create(formValues,
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