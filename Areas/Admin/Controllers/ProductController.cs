using Clothes_Online_Shop.DB.Data;
using Clothes_Online_Shop.DB.Models;
using Clothes_Online_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Clothes_Online_Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Index()
        {
            var productsDB = productsRepository.GetAll();
            var products = new List<ProductViewModel>();
            foreach (var productDB in productsDB)
            {
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
                    ImgPath = productDB.ImgPath,
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
            var productDB = new Product
            {
                Name = product.Name,
                Item = product.Item,
                Cost = product.Cost,
                Size = product.Size,
                Color = product.Color,
                Care = product.Care,
                Fabric = product.Fabric,
                Brand = product.Brand,
                Country = product.Country,
                Description = product.Description,
                ImgPath = product.ImgPath,
                Like = product.Like
            };
            productsRepository.AddProduct(productDB);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(Guid productId)
        {
            var productDB = productsRepository.TryGetById(productId);
            if (productDB == null)
            {
                return RedirectToAction(nameof(Index));
            }
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
                ImgPath = productDB.ImgPath,
                Like = productDB.Like
            };
            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(ProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            var productDB = new Product
            {
                Name = product.Name,
                Item = product.Item,
                Cost = product.Cost,
                Size = product.Size,
                Color = product.Color,
                Care = product.Care,
                Fabric = product.Fabric,
                Brand = product.Brand,
                Country = product.Country,
                Description = product.Description,
                ImgPath = product.ImgPath,
                Like = product.Like
            };
            productsRepository.Update(productDB);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(Guid productId)
        {
            var productDB = productsRepository.TryGetById(productId);
            if (productDB == null)
            {
                return RedirectToAction(nameof(Index));
            }
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
                ImgPath = productDB.ImgPath,
                Like = productDB.Like
            };
            return View(product);
        }
        public IActionResult DeleteProduct(Guid productId)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Product", productId);
            }
            productsRepository.Delete(productId);
            return RedirectToAction(nameof(Index));
        }
    }
}
