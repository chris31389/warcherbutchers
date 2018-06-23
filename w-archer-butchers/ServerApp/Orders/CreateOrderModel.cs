using System.Collections.Generic;

namespace WArcherButchers.ServerApp.Orders
{
    public class CreateOrderModel
    {
        public string CallbackUrl { get; set; }
        public CustomerDataModel CustomerData { get; set; }
        public IEnumerable<OrderSelectionModel> OrderSelections { get; set; }
    }
}