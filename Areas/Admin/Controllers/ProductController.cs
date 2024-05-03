using Clothes_Online_Shop.Data;
using Clothes_Online_Shop.Models;
using Microsoft.AspNetCore.Mvc;

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
            var products = productsRepository.GetAll();
            return View(products);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsRepository.AddProduct(product);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int productId)
        {
            var existingProduct = productsRepository.TryGetById(productId);
            if (existingProduct == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(existingProduct);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            productsRepository.Update(product);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int productId)
        {
            var existingProduct = productsRepository.TryGetById(productId);
            if (existingProduct == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(existingProduct);
        }
        public IActionResult DeleteProduct(int productId)
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
