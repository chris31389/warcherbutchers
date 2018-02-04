﻿namespace WArcherButchers.Infrastructure
{
    public struct Price
    {
        public Price(int major, int minor)
        {
            Major = major;
            Minor = minor;
        }

        public int Major, Minor;

        public int ToInt() => Major * 100 + Minor;
    }
}