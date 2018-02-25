using System;

namespace WArcherButchers.ServerApp.Products
{
    [Serializable]
    public class Weight
    {
        public string Unit { get; set; }
        public decimal Value { get; set; }
    }
}