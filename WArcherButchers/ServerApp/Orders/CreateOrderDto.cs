using System;
using System.Collections.Generic;

namespace WArcherButchers.ServerApp.Orders
{
    public class CreateOrderDto
    {
        public CustomerDataDto CustomerData { get; set; }
        public Dictionary<Guid,int> ProductSelection { get; set; }
    }
}