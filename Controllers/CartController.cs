using Clothes_Online_Shop.DB.Data;
using Clothes_Online_Shop.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Clothes_Online_Shop.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IImgInfosDBRepository imgInfosRepository;
        private readonly ICartsRepository cartsRepository;
        public CartController(IProductsRepository productsRepository, ICartsRepository cartsRepository, IImgInfosDBRepository imgInfosRepository)
        {
            this.productsRepository = productsRepository;
            this.cartsRepository = cartsRepository;
            this.imgInfosRepository = imgInfosRepository;
        }
        public IActionResult Index()
        {
            var cart = cartsRepository.TryGetByUserId(ShopUser.UserId);
            return View(Mapping.ToCartViewModel(cart));
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
