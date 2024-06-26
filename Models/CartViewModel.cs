﻿using Clothes_Online_Shop.DB;
using System;
using System.Collections.Generic;

namespace Clothes_Online_Shop.Models
{
    //корзина
    public class CartViewModel
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public List<CartItemViewModel> Items { get; set; }
        public int ItemsCount
        {
            get
            {
                int count = 0;
                foreach (var item in Items)
                {
                    count++;
                }
                return count;
            }
        }
        public int ProductsCount
        {
            get
            {
                int count = 0;
                foreach (var item in Items)
                {
                    count += item.Amount;
                }
                return count;
            }
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