using WArcherButchers.ServerApp.Infrastructure;

namespace WArcherButchers.ServerApp.Products
{
    public static class PricePerKiloHelper
    {
        public static Price CalculatePrice(Weight weight, Price price)
        {
            if (weight.Value == 0)
            {
                return price;
            }

            decimal grams = weight.Unit == "kg" ? weight.Value * 1000 : weight.Value * 1;
            int priceAsInt = price.ToInt();
            decimal cost = (priceAsInt * 1000 / grams) / 100;
            return new Price(cost);
        }
    }
}