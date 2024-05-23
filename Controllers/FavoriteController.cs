using Clothes_Online_Shop.DB.Data;
using Clothes_Online_Shop.Helpers;
using Clothes_Online_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Clothes_Online_Shop.Controllers
{
    public class FavoriteController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IFavoriteProductRepository favoriteRepository;
        public FavoriteController(IProductsRepository productsRepository, IFavoriteProductRepository favoriteRepository)
        {
            this.productsRepository = productsRepository;
            this.favoriteRepository = favoriteRepository;
        }
        public IActionResult Index()
        {
            var products = favoriteRepository.GetAll(ShopUser.UserId);
            return View(products.ToProductViewModels());
        }
        public IActionResult Add(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            favoriteRepository.Add(ShopUser.UserId, product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(Guid productId)
        {
            var product = productsRepository.TryGetById(productId);
            favoriteRepository.Remove(ShopUser.UserId, product);
            return RedirectToAction(nameof(Index));
        }
    }
}
