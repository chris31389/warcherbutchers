using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using WArcherButchers.ServerApp.PaymentSense;

namespace WArcherButchers.Tests.ServerApp.PaymentSense
{
    [TestFixture]
    public class HashDigestFactoryTests
    {
        private HashDigestFactory _hashDigestFactory;

        private readonly Dictionary<string, object> _formValues = new Dictionary<string, object>
        {
            {"MerchantID", "Test-2994724"},
            {"Amount", 100},
            {"CurrencyCode", 826},
            {"EchoAVSCheckResult", ""},
            {"EchoCV2CheckResult", ""},
            {"EchoThreeDSecureAuthenticationCheckResult", ""},
            {"EchoFraudProtectionCheckResult", ""},
            {"EchoCardType", ""},
            {"EchoCardNumberFirstSix", ""},
            {"EchoCardNumberLastFour", ""},
            {"EchoCardExpiryDate", ""},
            {"EchoDonationAmount", ""},
            {"AVSOverridePolicy", "EFFF"},
            {"CV2OverridePolicy", "FF"},
            {"ThreeDSecureOverridePolicy", ""},
            {"OrderID", "109j98nm9ij98v8v8v7-123dcvgff"},
            {"TransactionType", "SALE"},
            {"TransactionDateTime", "2018-02-03 14:15:00 +01:00"},
            {"DisplayCancelButton", ""},
            {"CallbackURL", "https://www.google.com/orders/109j98nm9ij98v8v8v7-123dcvgff"},
            {"OrderDescription", "Sale of Chilled Meat Products"},
            {"LineItemSalesTaxAmount", ""},
            {"LineItemSalesTaxDescription", ""},
            {"LineItemQuantity", ""},
            {"LineItemAmount", ""},
            {"LineItemDescription", ""},
            {"CustomerName", ""},
            {"DisplayBillingAddress", ""},
            {"Address1", ""},
            {"Address2", ""},
            {"Address3", ""},
            {"Address4", ""},
            {"City", ""},
            {"State", ""},
            {"PostCode", ""},
            {"CountryCode", ""},
            {"EmailAddress", ""},
            {"PhoneNumber", ""},
            {"DateOfBirth", ""},
            {"DisplayShippingDetails", ""},
            {"ShippingName", ""},
            {"ShippingAddress1", ""},
            {"ShippingAddress2", ""},
            {"ShippingAddress3", ""},
            {"ShippingAddress4", ""},
            {"ShippingCity", ""},
            {"ShippingState", ""},
            {"ShippingPostCode", ""},
            {"ShippingCountryCode", ""},
            {"ShippingEmailAddress", ""},
            {"ShippingPhoneNumber", ""},
            {"CustomerNameEditable", ""},
            {"EmailAddressEditable", ""},
            {"PhoneNumberEditable", ""},
            {"DateOfBirthEditable", ""},
            {"CV2Mandatory", true},
            {"Address1Mandatory", true},
            {"CityMandatory", true},
            {"PostCodeMandatory", true},
            {"StateMandatory", true},
            {"CountryMandatory", true},
            {"ShippingAddress1Mandatory", ""},
            {"ShippingCityMandatory", ""},
            {"ShippingPostCodeMandatory", ""},
            {"ShippingStateMandatory", ""},
            {"ShippingCountryMandatory", ""},
            {"ResultDeliveryMethod", "SERVER"},
            {"ServerResultURL", "https://www.google.com/confirmpayment"},
            {"PaymentFormDisplaysResult", false},
            {"ServerResultURLCookieVariables", ""},
            {"ServerResultURLFormVariables", ""},
            {"ServerResultURLQueryStringVariables", ""},
            {"PrimaryAccountName", ""},
            {"PrimaryAccountNumber", ""},
            {"PrimaryAccountDateOfBirth", ""},
            {"PrimaryAccountPostCode", ""},
            {"Skin", ""},
            {"PaymentFormContentMode", ""},
            {"BreakoutOfIFrameOnCallback", ""}
        };

        [SetUp]
        public void Setup()
        {
            _hashDigestFactory = new HashDigestFactory();
        }

        [TestCase("YourCo-1234567", 100, 826, "12345", "MyPassword", "ASecretKey",
            ExpectedResult = "0b1d23fda6ad5c1d85bb2426050c9d4f34f744d9")]
        [TestCase("YourCo-1234567", 10000, 826, "12345", "MyPassword", "ASecretKey",
            ExpectedResult = "9f7e81f8b3d91108db4085ac78a2d16d84880bec")]
        public string GivenSHA1AndSomeInputVariables_WhenICallCreate_ThenItGeneratesCorrectly(
            string merchantId, int amount, int currencyCode, string orderId, string password, string preSharedKey
        )
        {
            Dictionary<string, object> formValues = new Dictionary<string, object>
            {
                {"MerchantID", merchantId},
                {"Amount", amount},
                {"CurrencyCode", currencyCode},
                {"OrderID", orderId}
            };

            string hashDigest = _hashDigestFactory.Create(formValues, preSharedKey, password);
            return hashDigest;
        }

        [TestCase("YourCo-1234567", 100, 826, "12345", "MyPassword", "ASecretKey",
            ExpectedResult =
                "PreSharedKey=ASecretKey&MerchantID=YourCo-1234567&Password=MyPassword&Amount=100&CurrencyCode=826&OrderID=12345")]
        [TestCase("YourCo-1234567", 10000, 826, "12345", "MyPassword", "ASecretKey",
            ExpectedResult =
                "PreSharedKey=ASecretKey&MerchantID=YourCo-1234567&Password=MyPassword&Amount=10000&CurrencyCode=826&OrderID=12345")]
        public string GivenSHA1AndSomeInputVariables_WhenICallGetStringToHash_ThenItGeneratesCorrectly(
            string merchantId, int amount, int currencyCode, string orderId, string password, string preSharedKey
        )
        {
            Dictionary<string, object> formValues = new Dictionary<string, object>
            {
                {"MerchantID", merchantId},
                {"Amount", amount},
                {"CurrencyCode", currencyCode},
                {"OrderID", orderId}
            };

            string hashDigest = HashDigestFactory.GetStringToHash(formValues, preSharedKey, password);
            return hashDigest;
        }

        [Test]
        public void GivenSHA1AndSomeInputVariables_WhenICallCreate_ThenItGeneratesCorrectly2()
        {
            string hashDigest = _hashDigestFactory.Create(
                _formValues,
                "WwUbLs5oGMQqZVVHvw4XgxMefcWE2TXfW5zEUP/tzIqf+iBm5iUn85+sBkTeK3NFfrjVmzRHqTkR91oOesJR",
                "1q2aW3zSe4");

            Assert.That(hashDigest, Is.EqualTo("7173b116eef5ee8689588a084de5ca3f40a9fbf9"));
        }

        [Test]
        public void GivenSHA1AndSomeInputVariables_WhenICallGetStringToHash_ThenItGeneratesCorrectly2()
        {
            string hashDigest = HashDigestFactory.GetStringToHash(_formValues,
                "WwUbLs5oGMQqZVVHvw4XgxMefcWE2TXfW5zEUP/tzIqf+iBm5iUn85+sBkTeK3NFfrjVmzRHqTkR91oOesJR", "1q2aW3zSe4");

            Assert.That(hashDigest,
                Is.EqualTo(
                    "PreSharedKey=WwUbLs5oGMQqZVVHvw4XgxMefcWE2TXfW5zEUP/tzIqf+iBm5iUn85+sBkTeK3NFfrjVmzRHqTkR91oOesJR&MerchantID=Test-2994724&Password=1q2aW3zSe4&Amount=100&CurrencyCode=826&EchoAVSCheckResult=&EchoCV2CheckResult=&EchoThreeDSecureAuthenticationCheckResult=&EchoFraudProtectionCheckResult=&EchoCardType=&EchoCardNumberFirstSix=&EchoCardNumberLastFour=&EchoCardExpiryDate=&EchoDonationAmount=&AVSOverridePolicy=EFFF&CV2OverridePolicy=FF&ThreeDSecureOverridePolicy=&OrderID=109j98nm9ij98v8v8v7-123dcvgff&TransactionType=SALE&TransactionDateTime=2018-02-03 14:15:00 +01:00&DisplayCancelButton=&CallbackURL=https://www.google.com/orders/109j98nm9ij98v8v8v7-123dcvgff&OrderDescription=Sale of Chilled Meat Products&LineItemSalesTaxAmount=&LineItemSalesTaxDescription=&LineItemQuantity=&LineItemAmount=&LineItemDescription=&CustomerName=&DisplayBillingAddress=&Address1=&Address2=&Address3=&Address4=&City=&State=&PostCode=&CountryCode=&EmailAddress=&PhoneNumber=&DateOfBirth=&DisplayShippingDetails=&ShippingName=&ShippingAddress1=&ShippingAddress2=&ShippingAddress3=&ShippingAddress4=&ShippingCity=&ShippingState=&ShippingPostCode=&ShippingCountryCode=&ShippingEmailAddress=&ShippingPhoneNumber=&CustomerNameEditable=&EmailAddressEditable=&PhoneNumberEditable=&DateOfBirthEditable=&CV2Mandatory=true&Address1Mandatory=true&CityMandatory=true&PostCodeMandatory=true&StateMandatory=true&CountryMandatory=true&ShippingAddress1Mandatory=&ShippingCityMandatory=&ShippingPostCodeMandatory=&ShippingStateMandatory=&ShippingCountryMandatory=&ResultDeliveryMethod=SERVER&ServerResultURL=https://www.google.com/confirmpayment&PaymentFormDisplaysResult=false&ServerResultURLCookieVariables=&ServerResultURLFormVariables=&ServerResultURLQueryStringVariables=&PrimaryAccountName=&PrimaryAccountNumber=&PrimaryAccountDateOfBirth=&PrimaryAccountPostCode=&Skin=&PaymentFormContentMode=&BreakoutOfIFrameOnCallback="));
        }

        [Test]
        public void RunTest()
        {
            Dictionary<string, object> formValues = new Dictionary<string, object>
            {
                {"MerchantID", "Test-2994724"},
                {"Amount", 1359},
                {"CurrencyCode", 826},
                {"EchoAVSCheckResult", false},
                {"EchoCV2CheckResult", false},
                {"EchoThreeDSecureAuthenticationCheckResult", false},
                {"EchoCardType", false},
                {"AVSOverridePolicy", "EFFF"},
                {"CV2OverridePolicy", "FF"},
                {"ThreeDSecureOverridePolicy", false},
                {"OrderID", "5a772131054d021998f3a62d"},
                {"TransactionType", "SALE"},
                {"TransactionDateTime", "2018-02-04 15:05:22 +00:00"},
                {"CallbackURL", "https://warcher-api.azurewebsites.net/ordercomplete"},
                {"OrderDescription", "Sale of Chilled Meat Products"},
                {"CustomerName", ""},
                {"Address1", ""},
                {"Address2", ""},
                {"Address3", ""},
                {"Address4", ""},
                {"City", ""},
                {"State", ""},
                {"PostCode", ""},
                {"CountryCode", ""},
                {"EmailAddress", ""},
                {"PhoneNumber", ""},
                {"EmailAddressEditable", false},
                {"PhoneNumberEditable", false},
                {"CV2Mandatory", true},
                {"Address1Mandatory", true},
                {"CityMandatory", true},
                {"PostCodeMandatory", true},
                {"StateMandatory", true},
                {"CountryMandatory", true},
                {"ResultDeliveryMethod", "POST"},
                {"ServerResultURL", ""},
                {"PaymentFormDisplaysResult", false},
            };
            
            string hashDigest = _hashDigestFactory.Create(
                formValues,
                "WwUbLs5oGMQqZVVHvw4XgxMefcWE2TXfW5zEUP/tzIqf+iBm5iUn85+sBkTeK3NFfrjVmzRHqTkR91oOesJR",
                "1q2aW3zSe4");
            
            string form = GetStringForm(formValues, hashDigest);
            Console.WriteLine(form);
        }

        private static string GetStringForm(Dictionary<string, object> formValues, string hashDigest)
        {
            StringBuilder stringBuilder = new StringBuilder();
            formValues.ToList().ForEach(formValue =>
            {
                string value = formValue.Value is bool
                    ? formValue.Value.ToString().ToLower()
                    : formValue.Value.ToString();
                stringBuilder.AppendLine($"{formValue.Key}:{value}");
            });
            stringBuilder.AppendLine($"HashDigest:{hashDigest}");
            return stringBuilder.ToString();
        }

        [Test]
        public void RunTest3()
        {
            Dictionary<string, object> formValues = new Dictionary<string, object>
            {
                {"MerchantID", "Test-2994724"},
                {"Amount", 1359},
                {"CurrencyCode", 826},
                {"EchoAVSCheckResult", false},
                {"EchoCV2CheckResult", false},
                {"EchoThreeDSecureAuthenticationCheckResult", false},
                {"EchoCardType", false},
                {"AVSOverridePolicy", "EFFF"},
                {"CV2OverridePolicy", "FF"},
                {"ThreeDSecureOverridePolicy", false},
                {"OrderID", "5a772131054d021998f3a62d"},
                {"TransactionType", "SALE"},
                {"TransactionDateTime", DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss zzz")},
                {"CallbackURL", "https://warcher-api.azurewebsites.net/ordercomplete"},
                {"OrderDescription", "Sale of Chilled Meat Products"},
                {"CustomerName", ""},
                {"Address1", ""},
                {"Address2", ""},
                {"Address3", ""},
                {"Address4", ""},
                {"City", ""},
                {"State", ""},
                {"PostCode", ""},
                {"CountryCode", ""},
                {"EmailAddress", ""},
                {"PhoneNumber", ""},
                {"EmailAddressEditable", false},
                {"PhoneNumberEditable", false},
                {"CV2Mandatory", true},
                {"Address1Mandatory", true},
                {"CityMandatory", true},
                {"PostCodeMandatory", true},
                {"StateMandatory", true},
                {"CountryMandatory", true},
                {"ResultDeliveryMethod", "SERVER"},
                {"ServerResultURL", "https://www.google.com/confirmpayment"},
                {"PaymentFormDisplaysResult", false},
            };

            string hashDigest = _hashDigestFactory.Create(
                formValues,
                "WwUbLs5oGMQqZVVHvw4XgxMefcWE2TXfW5zEUP/tzIqf+iBm5iUn85+sBkTeK3NFfrjVmzRHqTkR91oOesJR",
                "1q2aW3zSe4");

            string form = GetStringForm(formValues, hashDigest);
            Console.WriteLine(form);
        }

        [Test]
        public void RunTest2()
        {
            Dictionary<string, object> formValues = new Dictionary<string, object>
            {
                {"MerchantID", "Test-2994724"},
                {"Amount", 1359},
                {"CurrencyCode", 826},
                {"EchoAVSCheckResult", false},
                {"EchoCV2CheckResult", false},
                {"EchoThreeDSecureAuthenticationCheckResult", false},
                {"EchoCardType", false},
                {"AVSOverridePolicy", "EFFF"},
                {"CV2OverridePolicy", "FF"},
                {"ThreeDSecureOverridePolicy", false},
                {"OrderID", "5a772131054d021998f3a62d"},
                {"TransactionType", "SALE"},
                {"TransactionDateTime", DateTimeOffset.Now.ToString("yyyy-MM-dd HH:mm:ss zzz")},
                {"CallbackURL", "https://warcher-api.azurewebsites.net/ordercomplete"},
                {"OrderDescription", "Sale of Chilled Meat Products"},
                {"CustomerName", ""},
                {"Address1", ""},
                {"Address2", ""},
                {"Address3", ""},
                {"Address4", ""},
                {"City", ""},
                {"State", ""},
                {"PostCode", ""},
                {"CountryCode", ""},
                {"EmailAddress", ""},
                {"PhoneNumber", ""},
                {"EmailAddressEditable", false},
                {"PhoneNumberEditable", false},
                {"CV2Mandatory", true},
                {"Address1Mandatory", true},
                {"CityMandatory", true},
                {"PostCodeMandatory", true},
                {"StateMandatory", true},
                {"CountryMandatory", true},
                {"ResultDeliveryMethod", "POST"},
                {"ServerResultURL", ""},
                {"PaymentFormDisplaysResult", false},
            };
            
            string hashDigest = _hashDigestFactory.Create(
                formValues,
                "WwUbLs5oGMQqZVVHvw4XgxMefcWE2TXfW5zEUP/tzIqf+iBm5iUn85+sBkTeK3NFfrjVmzRHqTkR91oOesJR",
                "1q2aW3zSe4");

            string form = GetStringForm(formValues, hashDigest);
            Console.WriteLine(form);
        }
    }
}