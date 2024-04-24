using System;
using System.Collections.Generic;

namespace Clothes_Online_Shop.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public UserDeliveryInfo UserInfo { get; set; }
        public List<CartItem> Items { get; set; }
        public Order()
        {
            Id = Guid.NewGuid();
        }
    }
}
