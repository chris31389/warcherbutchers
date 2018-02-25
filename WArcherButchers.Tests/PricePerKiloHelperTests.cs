using NUnit.Framework;
using WArcherButchers.ServerApp.Infrastructure;
using WArcherButchers.ServerApp.Products;

namespace WArcherButchers.Tests
{
    [TestFixture]
    public class PricePerKiloHelperTests
    {
        [TestCase(1, "kg", 5, 0, 5, 0)]
        [TestCase(1.8, "kg", 10, 0, 5, 55)]
        [TestCase(1.8, "kg", 18, 0, 10, 0)]
        [TestCase(500, "g", 5, 50, 11, 0)]
        [TestCase(500, "g", 5, 30, 10, 60)]
        [TestCase(500, "g", 5, 0, 10, 0)]
        public void GivenWeightAndPrice_WhenICalculatePricePerKilo_ThenItGivesMeEpectedPrice(
            decimal weightValue,
            string weightUnit,
            int priceMajor,
            int priceMinor,
            int perKiloPriceMajor,
            int perKiloPriceMinor
            )
        {
            Weight weight = new Weight
            {
                Unit = weightUnit,
                Value = weightValue
            };

            Price price = new Price(priceMajor, priceMinor);
            Price total = PricePerKiloHelper.CalculatePrice(weight, price);

            Assert.That(total.Major, Is.EqualTo(perKiloPriceMajor));
            Assert.That(total.Minor, Is.EqualTo(perKiloPriceMinor));
        }
    }
}