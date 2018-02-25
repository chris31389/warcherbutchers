using System.Collections.Generic;

namespace WArcherButchers.ServerApp.Orders
{
    public class CreateOrderOutModel
    {
        public OrderModel Order { get; set; }
        public IEnumerable<FormElementModel> FormDetails { get; set; }
    }
}