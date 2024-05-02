using Clothes_Online_Shop.Data;
using Clothes_Online_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Clothes_Online_Shop.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IOrdersRepository ordersRepository;
        private readonly IRolesRepository rolesRepository;

        public AdminController(IProductsRepository productsRepository, IOrdersRepository ordersRepository, IRolesRepository rolesRepository)
        {
            this.productsRepository = productsRepository;
            this.ordersRepository = ordersRepository;
            this.rolesRepository = rolesRepository;
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
        public IActionResult UpdateOrderStatus(Guid orderId, OrderStatus newStatus)
        {
            ordersRepository.UpdateStatus(orderId, newStatus);
            return RedirectToAction("Orders");
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Roles()
        {
            var roles = rolesRepository.GetAll();
            return View(roles);
        }
        public IActionResult RemoveRole(string roleName)
        {
            rolesRepository.Remove(roleName);
            return RedirectToAction("Roles");
        }
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            if (rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", $"{role.Name} уже есть!");
            }
            if (ModelState.IsValid)
            {
                rolesRepository.AddRole(role);
                return RedirectToAction("Roles");
            }
            return View(role);
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
