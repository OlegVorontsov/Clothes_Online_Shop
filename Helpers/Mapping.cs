﻿using Clothes_Online_Shop.DB.Data;
using Clothes_Online_Shop.DB.Models;
using Clothes_Online_Shop.Models;
using System;
using System.Collections.Generic;

namespace Clothes_Online_Shop.Helpers
{
    public static class Mapping
    {
        public static List<ProductViewModel> ToProductViewModels(this List<Product> products)
        {
            var productsViewModels = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productsViewModels.Add(ToProductViewModel(product));
            }
            return productsViewModels;
        }
        public static ProductViewModel ToProductViewModel(this Product product)
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
        public static Product ToProduct(this ProductViewModel productViewModel)
        {
            return new Product
            {
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                Item = productViewModel.Item,
                Cost = productViewModel.Cost,
                Size = productViewModel.Size,
                Color = productViewModel.Color,
                Care = productViewModel.Care,
                Fabric = productViewModel.Fabric,
                Brand = productViewModel.Brand,
                Country = productViewModel.Country,
                Description = productViewModel.Description,
                ImgList = productViewModel.ImgList,
                Like = productViewModel.Like
            };
        }

        public static UserDeliveryInfo ToUser(this UserDeliveryInfoViewModel userInfo)
        {
            return new UserDeliveryInfo
            {
                Email = userInfo.Email,
                Name = userInfo.Name,
                Phone = userInfo.Phone
            };
        }

        public static CartViewModel ToCartViewModel(this Cart cart)
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
        public static List<CartItemViewModel> ToCartItemViewModels(this List<CartItem> cartDBItems)
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
        public static OrderViewModel ToOrderViewModel (this Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                CreatedDateTime = order.CreatedDateTime,
                Status = (OrderStatusViewModel)(int)order.Status,
                UserInfo = ToUserDeliveryInfoViewModel(order.UserInfo),
                Items = ToCartItemViewModels(order.Items)
            };
        }
        public static UserDeliveryInfoViewModel ToUserDeliveryInfoViewModel(this UserDeliveryInfo userInfo)
        {
            return new UserDeliveryInfoViewModel
            {
                Name = userInfo.Name,
                Email = userInfo.Email,
                Phone = userInfo.Phone
            };
        }
        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel
            {
                Name = user.UserName,
                Email = user.Email,
                Phone = user.PhoneNumber
            };
        }
    }
}
