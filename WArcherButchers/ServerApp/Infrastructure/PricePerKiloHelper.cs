using System;
using WArcherButchers.ServerApp.Products;

namespace WArcherButchers.ServerApp.Infrastructure
{
    public static class PricePerKiloHelper
    {
        public static Price CalculatePrice(Weight weight, Price price)
        {
            decimal grams = weight.Unit == "kg" ? weight.Value * 1000 : weight.Value * 1;
            int priceAsInt = price.ToInt();
            decimal cost = (priceAsInt * 1000 / grams) / 100;
            return new Price(cost);
        }
    }
}