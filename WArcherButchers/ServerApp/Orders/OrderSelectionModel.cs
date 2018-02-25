using System;

namespace WArcherButchers.ServerApp.Orders
{
    public class OrderSelectionModel
    {
        public Guid ProductId { get; set; }
        public Guid VariationId { get; set; }
        public int Quantity { get; set; }
    }
}