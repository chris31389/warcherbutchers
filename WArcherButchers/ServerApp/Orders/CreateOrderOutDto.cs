using System.Collections.Generic;

namespace WArcherButchers.ServerApp.Orders
{
    public class CreateOrderOutDto
    {
        public OrderDto Order { get; set; }
        public IEnumerable<FormElementDto> FormDetails { get; set; }
    }
}