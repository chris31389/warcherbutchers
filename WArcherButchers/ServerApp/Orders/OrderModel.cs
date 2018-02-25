using System;
using WArcherButchers.Infrastructure;

namespace WArcherButchers.ServerApp.Orders
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public Price Price { get; set; }
    }
}