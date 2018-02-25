using System;

namespace WArcherButchers.ServerApp.Infrastructure
{
    [Serializable]
    public class Price
    {
        public Price(int major, int minor)
        {
            Major = major;
            Minor = minor;
        }

        public Price(decimal total)
        {
            Major = (int) total;
            Console.WriteLine((int)total);
            Console.WriteLine(total-(int)total);
            Console.WriteLine((total-(int)total)*100);
            Console.WriteLine((int)((total-(int)total)*100));
            Minor = (int) ((total - (int)total) * 100);
        }

        public int Major { get; protected set; }
        public int Minor { get; protected set; }

        public int ToInt() => Major * 100 + Minor;
    }
}