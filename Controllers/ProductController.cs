using Clothes_Online_Shop.DB.Data;
using Clothes_Online_Shop.Helpers;
using Clothes_Online_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Clothes_Online_Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly ImagesProvider ImagesProvider;

        public ProductController(IProductsRepository productsRepository, ImagesProvider ImagesProvider)
        {
            this.productsRepository = productsRepository;
            this.ImagesProvider = ImagesProvider;
        }

        public IActionResult Catalog()
        {
            var productsDB = productsRepository.GetAll();
            return View(productsDB.ToProductViewModels());
        }

        public IActionResult Index(Guid id)
        {
            var productDB = productsRepository.TryGetById(id);
            if (productDB == null)
            {
                object result = $"Товар с id {id} отсутствует";
                return View("Error", result);
            }
            return View(productDB.ToProductViewModel());
        }
    }
}
