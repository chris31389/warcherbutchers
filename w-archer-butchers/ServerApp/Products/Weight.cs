using System;
using WArcherButchers.ServerApp.Infrastructure.Entities;

namespace WArcherButchers.ServerApp.Products
{
    public class Weight : SubEntity
    {
        public string Unit { get; protected set; }
        public decimal Value { get; protected set; }

        public Weight(Guid entityId, string unit, decimal value) : base(entityId)
        {
            Unit = unit;
            Value = value;
        }

        public Weight()
        {
        }
    }
}