using Clothes_Online_Shop.Data;
using Microsoft.AspNetCore.Mvc;

namespace Clothes_Online_Shop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public AdminController(IProductsRepository productsRepository)
        {
            this.productsRepository = productsRepository;
        }

        public IActionResult Orders()
        {
            return View();
        }
        public IActionResult Users()
        {
            return View();
        }
        public IActionResult Roles()
        {
            return View();
        }
        public IActionResult Products()
        {
            var products = productsRepository.GetAll();
            return View(products);
        }
    }
}
