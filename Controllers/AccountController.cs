using Clothes_Online_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clothes_Online_Shop.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login loginInfo)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
