using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WArcherButchers.ServerApp.Infrastructure;

namespace WArcherButchers.ServerApp.Products
{
    [Serializable]
    public class Variation : IEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string ImageId { get; set; }
        public string ImageUrl { get; set; }
        public string Alt { get; set; }
        public Weight Weight { get; set; }
        public Price Price { get; set; }
    }
}