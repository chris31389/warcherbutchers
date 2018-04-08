using NUnit.Framework;
using WArcherButchers.ServerApp.Infrastructure;

namespace WArcherButchers.Tests.ServerApp.Infrastructure
{
    [TestFixture]
    public class PriceTests
    {
        [Test]
        public void GivenAPriceOf1250_WhenIGetInt_ThenItGivesMe1250()
        {
            Price price = new Price(1250);
            Assert.That(price.ToInt(), Is.EqualTo(1250));
        }

        [Test]
        public void GivenAPriceOf150_WhenIGetMajor_ItGivesMe1()
        {
            Price price = new Price(150);
            Assert.That(price.Major, Is.EqualTo(1));
        }

        [Test]
        public void GivenAPriceOf150_WhenIGetMinor_ItGivesMe50()
        {
            Price price = new Price(150);
            Assert.That(price.Major, Is.EqualTo(1));
        }
    }
}