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
        private readonly ImagesProvider ImagesProvider;

        public ProductController(IProductsRepository productsRepository, ImagesProvider imgInfosRepository)
        {
            this.productsRepository = productsRepository;
            this.ImagesProvider = imgInfosRepository;
        }

        public IActionResult Index()
        {
            var productsDB = productsRepository.GetAll();
            return View(productsDB.ToProductViewModels());
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(AddProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            var imagePaths = ImagesProvider.SafeFiles(product.UploadedFiles, ImageFolders.Products);
            productsRepository.AddProduct(product.ToProduct(imagePaths));
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(Guid productId)
        {
            var productDB = productsRepository.TryGetById(productId);
            if (productDB == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(productDB.ToEditProductViewModel());
        }
        [HttpPost]
        public IActionResult Edit(EditProductViewModel product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            var addedImagePaths = ImagesProvider.SafeFiles(product.UploadedFiles, ImageFolders.Products);
            product.ImagesPaths = addedImagePaths;
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
