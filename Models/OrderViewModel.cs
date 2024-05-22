using System;
using System.Collections.Generic;

namespace Clothes_Online_Shop.Models
{
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public UserDeliveryInfoViewModel UserInfo { get; set; }
        public List<CartItemViewModel> Items { get; set; }
        public OrderStatusViewModel Status { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public OrderViewModel()
        {
            Id = Guid.NewGuid();
            Status = OrderStatusViewModel.Created;
            CreatedDateTime = DateTime.Now;
        }
        public decimal TotalCost
        {
            get
            {
                decimal total = 0;
                foreach (var item in Items)
                {
                    total += item.Cost;
                }
                return total;
            }
        }
        public decimal FullCost
        {
            get
            {
                return TotalCost + ShopUser.UserDelivery - ShopUser.UserSale;
            }
        }
    }
}
