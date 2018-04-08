using System;
using WArcherButchers.ServerApp.Infrastructure.Entities;

namespace WArcherButchers.ServerApp.Products
{
    public class Variation : SubEntity
    {
        public string Name { get; set; }
        public string ImageId { get; set; }
        public string ImageUrl { get; set; }
        public string Alt { get; set; }
        public Weight Weight { get; set; }
        public int Price { get; set; }

        public Variation(Guid entityId, VariationDto variationDto) : base(entityId)
        {
            Name = variationDto.Name;
            ImageId = variationDto.ImageId;
            ImageUrl = variationDto.ImageUrl;
            Alt = variationDto.Alt;
            Price = variationDto.Price;
            Weight = new Weight(entityId, variationDto.WeightUnit, variationDto.WeightValue);
        }

        public Variation()
        {
        }
    }
}