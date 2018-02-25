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

        public int Major { get; protected set; }
        public int Minor { get; protected set; }

        public int ToInt() => Major * 100 + Minor;
    }
}