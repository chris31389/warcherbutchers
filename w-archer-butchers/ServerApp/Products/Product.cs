using System.Collections.Generic;
using System.Linq;
using WArcherButchers.ServerApp.Infrastructure.Entities;

namespace WArcherButchers.ServerApp.Products
{
    public class Product : Entity
    {
        private List<Category> _categories = new List<Category>();
        private List<Variation> _variations = new List<Variation>();

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string DetailedDescription { get; protected set; }
        public bool Speciality { get; protected set; }

        public IEnumerable<Category> Categories
        {
            get => _categories.AsReadOnly();
            protected set
            {
                if (value != null) _categories = value.ToList();
            }
        }

        public IEnumerable<Variation> Variations
        {
            get => _variations;
            protected set
            {
                if (value != null) _variations = value.ToList();
            }
        }

        public void AddVariation(VariationDto variationDto)
        {
            _variations.Add(new Variation(Id, variationDto));
        }
    }
}