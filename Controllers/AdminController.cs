using Clothes_Online_Shop.Data;
using Clothes_Online_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Clothes_Online_Shop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IOrdersRepository ordersRepository;

        public AdminController(IProductsRepository productsRepository, IOrdersRepository ordersRepository)
        {
            this.productsRepository = productsRepository;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Orders()
        {
            var orders = ordersRepository.GetAll();
            return View(orders);
        }

        public IActionResult OrderDetails(Guid orderId)
        {
            var order = ordersRepository.TryGetById(orderId);
            return View(order);
        }
        public IActionResult DeleteOrder(Guid orderId)
        {
            if (!ModelState.IsValid)
            {
                var order = ordersRepository.TryGetById(orderId);
                return RedirectToAction("Index", "Order", order.UserInfo);
            }
            ordersRepository.DeleteOrder(orderId);
            return RedirectToAction("Orders");
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult Products()
        {
            var products = productsRepository.GetAll();
            return View(products);
        }
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsRepository.AddProduct(product);
            return RedirectToAction("Products");
        }
        public IActionResult EditProduct(int productId)
        {
            var existingProduct = productsRepository.TryGetById(productId);
            if (existingProduct == null)
            {
                return RedirectToAction("Products");
            }
            return View(existingProduct);
        }
        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsRepository.Update(product);
            return RedirectToAction("Products");
        }
        public IActionResult Delete(int productId)
        {
            var existingProduct = productsRepository.TryGetById(productId);
            if (existingProduct == null)
            {
                return RedirectToAction("Products");
            }
            return View(existingProduct);
        }

        public IActionResult DeleteProduct(int productId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Product", productId);
            }
            productsRepository.Delete(productId);
            return RedirectToAction("Products");
        }
    }
}
