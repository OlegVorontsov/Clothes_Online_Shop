using Clothes_Online_Shop.Data;
using Clothes_Online_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Clothes_Online_Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IOrdersRepository ordersRepository;

        public OrderController(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            var orders = ordersRepository.GetAll();
            return View(orders);
        }

        public IActionResult Details(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
            return View(order);
        }
        public IActionResult Delete(Guid orderId)
        {
            if (!ModelState.IsValid)
            {
                var order = ordersRepository.TryGetById(orderId);
                return RedirectToAction("Index", "Order", order.UserInfo);
            }
            ordersRepository.DeleteOrder(orderId);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult UpdateStatus(Guid orderId, OrderStatus newStatus)
        {
            ordersRepository.UpdateStatus(orderId, newStatus);
            return RedirectToAction(nameof(Index));
        }
    }
}
