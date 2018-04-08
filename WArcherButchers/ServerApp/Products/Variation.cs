using System;
using WArcherButchers.ServerApp.Infrastructure;
using WArcherButchers.ServerApp.Infrastructure.Entities;

namespace WArcherButchers.ServerApp.Products
{
    [Serializable]
    public class Variation : SubEntity
    {
        public string Name { get; set; }
        public string ImageId { get; set; }
        public string ImageUrl { get; set; }
        public string Alt { get; set; }
        public Weight Weight { get; set; }
        public Price Price { get; set; }
    }
}