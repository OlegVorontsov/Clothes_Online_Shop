using Clothes_Online_Shop.DB;
using Clothes_Online_Shop.DB.Data;
using Clothes_Online_Shop.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Clothes_Online_Shop.Controllers
{
    [Authorize]
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
            return View(cart.ToCartViewModel());
        }

        public IActionResult Add(Guid productId)
        {
            var productDB = productsRepository.TryGetById(productId);
            cartsRepository.Add(productDB, ShopUser.UserId);
            return RedirectToAction("Index");
        }

        public IActionResult DecreaseAmount(Guid productId)
        {
            cartsRepository.DecreaseAmount(productId, ShopUser.UserId);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteItem(Guid productId)
        {
            cartsRepository.DeleteItem(productId, ShopUser.UserId);
            return RedirectToAction("Index");
        }
    }
}
