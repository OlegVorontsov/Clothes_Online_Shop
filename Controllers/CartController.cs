﻿using Clothes_Online_Shop.Data;
using Clothes_Online_Shop.DB.Data;
using Clothes_Online_Shop.DB.Models;
using Clothes_Online_Shop.Models;
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
            return View(cart);
        }

        public IActionResult Add(Guid productId)
        {
            var productDB = productsRepository.TryGetById(productId);
            var imgInfosDB = imgInfosRepository.GetAllByProductId(productDB.Id);
            var product = new ProductViewModel
            {
                Id = productDB.Id,
                Name = productDB.Name,
                Item = productDB.Item,
                Cost = productDB.Cost,
                Size = productDB.Size,
                Color = productDB.Color,
                Care = productDB.Care,
                Fabric = productDB.Fabric,
                Brand = productDB.Brand,
                Country = productDB.Country,
                Description = productDB.Description,
                ImgList = imgInfosDB,
                Like = productDB.Like
            };
            cartsRepository.Add(product, ShopUser.UserId);
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
