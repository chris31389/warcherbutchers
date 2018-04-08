using NUnit.Framework;
using WArcherButchers.ServerApp.Infrastructure;

namespace WArcherButchers.Tests.ServerApp.Infrastructure
{
    [TestFixture]
    public class PriceTests
    {
        [Test]
        public void GivenAPriceOf12Major50Minor_WhenIGetInt_ThenItGivesMe1250()
        {
            Price price = new Price(12, 50);
            Assert.That(price.ToInt(), Is.EqualTo(1250));
        }

        [TestCase(12.50, 12, 50)]
        [TestCase(12.509, 12, 50)]
        [TestCase(12.60, 12, 60)]
        public void GivenDouble_WhenICreatePrice_ThenItGivesMeCorrectValue(
            decimal total,
            int priceMajor,
            int priceMinor
        )
        {
            Price price = new Price(total);
            Assert.That(price.Major, Is.EqualTo(priceMajor));
            Assert.That(price.Minor, Is.EqualTo(priceMinor));
        }
    }
}