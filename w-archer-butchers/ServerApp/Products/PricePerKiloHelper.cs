namespace WArcherButchers.ServerApp.Products
{
    public static class PricePerKiloHelper
    {
        public static int CalculatePrice(Weight weight, int price)
        {
            if (weight.Value == 0)
            {
                return price;
            }

            decimal grams = weight.Unit == "kg" ? weight.Value * 1000 : weight.Value;
            decimal cost = price * 1000 / grams;
            return decimal.ToInt32(cost);
        }
    }
}