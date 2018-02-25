using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WArcherButchers.ServerApp.Infrastructure;

namespace WArcherButchers.ServerApp.Products
{
    [Serializable]
    public class Product : IEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Animal { get; set; }
        public IEnumerable<string> Categories { get; set; }
        public string Description { get; set; }
        public string DetailedDescription { get; set; }
        public bool Speciality { get; set; }
        public IEnumerable<Variation> Variations { get; set; }
    }
}