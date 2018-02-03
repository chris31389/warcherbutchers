using System;

namespace WArcherButchers.ServerApp.Orders
{
    public class OrderSelectionDto
    {
        public Guid ProductId { get; set; }
        public Guid VariationId { get; set; }
        public int quantity { get; set; }
    }
}