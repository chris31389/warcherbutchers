using System.Collections.Generic;

namespace WArcherButchers.ServerApp.Orders
{
    public class CreateOrderDto
    {
        public string CallbackUrl { get; set; }
        public CustomerDataDto CustomerData { get; set; }
        public IEnumerable<OrderSelectionDto> OrderSelections { get; set; }
    }
}