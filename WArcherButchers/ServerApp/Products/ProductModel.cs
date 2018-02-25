using System.Collections.Generic;
using WArcherButchers.Infrastructure;

namespace WArcherButchers.ServerApp.Products
{
    public class ProductModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public string Description { get; set; }
        public string DetailedDescription { get; set; }
        public string ImageId { get; set; }
        public string ImageUrl { get; set; }
        public string VariationId { get; set; }
        public Price? PricePerKilo { get; set; }
        public Price? Price { get; set; }
        public Price? OldPrice { get; set; }
        public bool IsSpeciality { get; set; }
        public WeightModel Weight { get; set; }
    }
}