using Clothes_Online_Shop.Data;
using Clothes_Online_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Online_Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductRepository repository;

        public HomeController()
        {
            repository = new ProductRepository();
        }

        public string Index()
        {
            string line = string.Empty;
            foreach (var product in repository.GetAll())
            {
                line += product + "\n\n";
            }
            return line;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
