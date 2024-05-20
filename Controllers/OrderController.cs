﻿using Clothes_Online_Shop.Data;
using Clothes_Online_Shop.DB.Data;
using Clothes_Online_Shop.Helpers;
using Clothes_Online_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clothes_Online_Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersRepository;
        }

        [HttpPost]
        public IActionResult Buy(UserDeliveryInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Cart", userInfo);
            }
            var existingCart =  cartsRepository.TryGetByUserId(ShopUser.UserId);
            var existingCartViewModel = Mapping.ToCartViewModel(existingCart);
            var newOrder = new Order { UserInfo = userInfo, Items = existingCartViewModel.Items };
            ordersRepository.Add(newOrder);
            cartsRepository.Clear(ShopUser.UserId);
            return RedirectToAction("Catalog", "Product");
        }
    }
}
