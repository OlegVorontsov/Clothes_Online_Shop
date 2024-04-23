using Clothes_Online_Shop.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Online_Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public ProductController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Catalog()
        {
            return View(productsRepository.GetAll());
        }

        public IActionResult Index(int id)
        {
            var product = productsRepository.TryGetById(id);
            if (product == null)
            {
                object result = $"Товар с id {id} отсутствует";
                return View("Error", result);
            }
            return View(product);
        }
    }
}
