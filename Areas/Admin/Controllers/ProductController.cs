using Clothes_Online_Shop.DB;
using Clothes_Online_Shop.DB.Data;
using Clothes_Online_Shop.Helpers;
using Clothes_Online_Shop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Clothes_Online_Shop.Areas.Admin.Controllers
{
    [Area(ShopUser.AdminRoleName)]
    [Authorize(Roles = ShopUser.AdminRoleName)]
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IImgInfosDBRepository imgInfosRepository;

        public ProductController(IProductsRepository productsRepository, IImgInfosDBRepository imgInfosRepository)
        {
            this.productsRepository = productsRepository;
            this.imgInfosRepository = imgInfosRepository;
        }

        public IActionResult Index()
        {
            var productsDB = productsRepository.GetAll();
            var products = new List<ProductViewModel>();
            foreach (var productDB in productsDB)
            {
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
                products.Add(product);
            }
            return View(products);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsRepository.AddProduct(product.ToProduct());
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(Guid productId)
        {
            var productDB = productsRepository.TryGetById(productId);
            if (productDB == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(productDB.ToProductViewModel());
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsRepository.Update(product.ToProduct());
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(Guid productId)
        {
            var productDB = productsRepository.TryGetById(productId);
            if (productDB == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(productDB.ToProductViewModel());
        }
        public IActionResult DeleteProduct(Guid productId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Product", productId);
            }
            var listOfOrders = productsRepository.CheckProductInItems(productId);
            if (listOfOrders.Count != 0)
            {
                return View("Error", listOfOrders);
            }
            productsRepository.Delete(productId);
            return RedirectToAction(nameof(Index));
        }
    }
}
