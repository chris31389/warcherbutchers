using System;
using WArcherButchers.ServerApp.Infrastructure.Entities;

namespace WArcherButchers.ServerApp.Products
{
    public class Category : SubEntity
    {
        public string Name { get; protected set; }

        public Category(Guid entityId) : base(entityId)
        {
        }

        public Category()
        {
        }
    }
}