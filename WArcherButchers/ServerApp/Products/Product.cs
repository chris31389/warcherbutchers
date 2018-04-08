using System;
using System.Collections.Generic;
using WArcherButchers.ServerApp.Infrastructure.Entities;

namespace WArcherButchers.ServerApp.Products
{
    [Serializable]
    public class Product : Entity
    {
        public string Name { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public string Description { get; set; }
        public string DetailedDescription { get; set; }
        public bool Speciality { get; set; }
        public IEnumerable<Variation> Variations { get; set; }
    }
}