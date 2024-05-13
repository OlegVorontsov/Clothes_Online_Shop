using Clothes_Online_Shop.DB.Data;
using Clothes_Online_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace Clothes_Online_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductsRepository productsRepository;

        public HomeController(IProductsRepository productsRepository)
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
