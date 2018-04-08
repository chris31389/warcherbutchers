using System;
using NUnit.Framework;
using WArcherButchers.ServerApp.Products;

namespace WArcherButchers.Tests.ServerApp.Products
{
    [TestFixture]
    public class PricePerKiloHelperTests
    {
        [TestCase(1, "kg", 500, 500)]
        [TestCase(1.8, "kg", 1000, 555)]
        [TestCase(1.8, "kg", 1800, 1000)]
        [TestCase(500, "g", 550, 1100)]
        [TestCase(500, "g", 530, 1060)]
        [TestCase(500, "g", 500, 1000)]
        public void GivenWeightAndPrice_WhenICalculatePricePerKilo_ThenItGivesMeEpectedPrice(
            decimal weightValue,
            string weightUnit,
            int price,
            int perKiloPrice
            )
        {
            Weight weight = new Weight(Guid.Empty, weightUnit, weightValue);
            int total = PricePerKiloHelper.CalculatePrice(weight, price);
            Assert.That(total, Is.EqualTo(perKiloPrice));
        }
    }
}