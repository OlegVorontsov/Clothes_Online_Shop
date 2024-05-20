﻿using Clothes_Online_Shop.DB.Models;
using Clothes_Online_Shop.Models;
using System.Collections.Generic;

namespace Clothes_Online_Shop.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(ToProductViewModel(product));
            }
            return productsViewModels;
        }
        public static ProductViewModel ToProductViewModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Item = product.Item,
                Cost = product.Cost,
                Size = product.Size,
                Color = product.Color,
                Care = product.Care,
                Fabric = product.Fabric,
                Brand = product.Brand,
                Country = product.Country,
                Description = product.Description,
                ImgList = product.ImgList,
                Like = product.Like
            };
        }
        public static CartViewModel ToCartViewModel(Cart cart)
        {
            if (cart == null)
            {
                return null;
            }
            return new CartViewModel
            {
                Id = cart.Id,
                Items = ToCartItemViewModels(cart.Items),
                UserId = cart.UserId
            };
        }
        public static List<CartItemViewModel> ToCartItemViewModels(List<CartItem> cartDBItems)
        {
            var cartItems = new List<CartItemViewModel>();
            foreach (var cartDBItem in cartDBItems)
            {
                var cartItem = new CartItemViewModel
                {
                    Id = cartDBItem.Id,
                    Amount = cartDBItem.Amount,
                    Product = ToProductViewModel(cartDBItem.Product)
                };
                cartItems.Add(cartItem);
            }
            return cartItems;
        }
    }
}