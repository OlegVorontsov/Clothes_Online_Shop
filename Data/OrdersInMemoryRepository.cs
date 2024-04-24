using Clothes_Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clothes_Online_Shop.Data
{
    //хранилище заказов
    public class OrdersInMemoryRepository : IOrdersRepository
    {
        private List<Order> orders = new List<Order>();

        public void Add(Order order)
        {
            orders.Add(order);
        }
    }
}
