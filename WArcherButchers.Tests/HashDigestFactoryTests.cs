using System.Collections.Generic;
using NUnit.Framework;
using WArcherButchers.ServerApp.PaymentSense;

namespace WArcherButchers.Tests
{
    [TestFixture]
    public class HashDigestFactoryTests
    {
        private HashDigestFactory _hashDigestFactory;

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
            ExpectedResult = "PreSharedKey=ASecretKey&MerchantID=YourCo-1234567&Password=MyPassword&Amount=100&CurrencyCode=826&OrderID=12345")]
        [TestCase("YourCo-1234567", 10000, 826, "12345", "MyPassword", "ASecretKey",
            ExpectedResult = "PreSharedKey=ASecretKey&MerchantID=YourCo-1234567&Password=MyPassword&Amount=10000&CurrencyCode=826&OrderID=12345")]
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
    }
}