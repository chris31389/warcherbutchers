namespace WArcherButchers.ServerApp.Infrastructure
{
    public class Price
    {
        private readonly int _total;

        public Price(int total)
        {
            _total = total;
        }

        public int Major => _total / 100;
        public int Minor => _total % 100;

        public int ToInt() => _total;
    }
}