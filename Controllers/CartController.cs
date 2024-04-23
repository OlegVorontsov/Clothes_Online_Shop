using Clothes_Online_Shop.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Online_Shop.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ICartsRepository cartsRepository;
        public CartController(IProductsRepository productsRepository, ICartsRepository cartsRepository)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
        }
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(ShopUser.UserId);
            return View(cart);
        }

        public IActionResult Add(int productId)
        {
            var product = productsRepository.TryGetById(productId);
            cartsRepository.Add(product, ShopUser.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult DecreaseAmount(int productId)
        {
            cartsRepository.DecreaseAmount(productId, ShopUser.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteItem(int productId)
        {
            cartsRepository.DeleteItem(productId, ShopUser.UserId);
            return RedirectToAction("Index");
        }
    }
}
