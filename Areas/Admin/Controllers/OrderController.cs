using Clothes_Online_Shop.Data;
using Clothes_Online_Shop.DB.Data;
using Clothes_Online_Shop.DB.Models;
using Clothes_Online_Shop.Helpers;
using Clothes_Online_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

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
            return View(orders.Select(x => Mapping.ToOrderViewModel(x)).ToList());
        }

        public IActionResult Details(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
            return View(Mapping.ToOrderViewModel(order));
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
        public IActionResult UpdateStatus(Guid orderId, OrderStatusViewModel newStatus)
        {
            ordersRepository.UpdateStatus(orderId, (OrderStatus)(int)newStatus);
            return RedirectToAction(nameof(Index));
        }
    }
}
