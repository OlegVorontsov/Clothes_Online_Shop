using Clothes_Online_Shop.Data;
using Clothes_Online_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public IActionResult Index(Order order)
        {
            return View(order);
        }

        public IActionResult Buy(Order order)
        {
            var existingCart =  cartsRepository.TryGetByUserId(ShopUser.UserId);
            ordersRepository.Add(existingCart);
            cartsRepository.Clear(ShopUser.UserId);
            return RedirectToAction("Catalog", "Product");
        }
    }
}
