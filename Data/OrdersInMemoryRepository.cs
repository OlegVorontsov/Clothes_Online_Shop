using Clothes_Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Clothes_Online_Shop.Data
{
    //хранилище заказов
    public class OrdersInMemoryRepository : IOrdersRepository
    {
        private List<Cart> orders = new List<Cart>();

        public void Add(Cart cart)
        {
            orders.Add(cart);
        }
    }
}
