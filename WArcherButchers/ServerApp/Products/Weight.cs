using System;

namespace WArcherButchers.ServerApp.Products
{
    [Serializable]
    public class Weight
    {
        public string Unit { get; set; }
        public double Value { get; set; }
    }
}