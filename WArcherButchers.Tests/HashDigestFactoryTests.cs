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
            ExpectedResult = "4ba1164acbec732c18cd6e5f632adcdd4b440237")]
        [TestCase("YourCo-1234567", 10000, 826, "12345", "MyPassword", "ASecretKey",
            ExpectedResult = "5c6b9c913b2301e9aa6ff488b06e09273cded2a5")]
        public string GivenSHA1AndSomeInputVariables_WhenICallCreate_ThenItGeneratesCorrectly(
            string merchantId, int amount, int currencyCode, string orderId, string password, string preSharedKey
        )
        {
            PaymentSenseRequestDto paymentSenseRequestDto = new PaymentSenseRequestDto
            {
                AmountInPence = amount,
                CurrencyCode = currencyCode,
                MerchantID = merchantId,
                OrderID = orderId,
                Password = password,
                PreSharedKey = preSharedKey
            };
            string hashDigest = _hashDigestFactory.Create(paymentSenseRequestDto);
            return hashDigest;
        }

        [TestCase("YourCo-1234567", 100, 826, "12345", "MyPassword", "ASecretKey",
            ExpectedResult = "MerchantID=YourCo-1234567&Password=MyPassword&PreSharedKey=ASecretKey&Amount=100&CurrencyCode=826&OrderID=12345")]
        [TestCase("YourCo-1234567", 10000, 826, "12345", "MyPassword", "ASecretKey",
            ExpectedResult = "MerchantID=YourCo-1234567&Password=MyPassword&PreSharedKey=ASecretKey&Amount=10000&CurrencyCode=826&OrderID=12345")]
        public string GivenSHA1AndSomeInputVariables_WhenICallGetStringToHash_ThenItGeneratesCorrectly(
            string merchantId, int amount, int currencyCode, string orderId, string password, string preSharedKey
        )
        {
            PaymentSenseRequestDto paymentSenseRequestDto = new PaymentSenseRequestDto
            {
                AmountInPence = amount,
                CurrencyCode = currencyCode,
                MerchantID = merchantId,
                OrderID = orderId,
                Password = password,
                PreSharedKey = preSharedKey
            };

            string hashDigest = HashDigestFactory.GetStringToHash(paymentSenseRequestDto);
            return hashDigest;
        }
    }
}