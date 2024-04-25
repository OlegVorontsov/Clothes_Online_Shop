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
            if (loginInfo.Email == loginInfo.Password)
            {
                ModelState.AddModelError("", "e-mail и пароль не должны совпадать");
            }
            if (ModelState.IsValid)
            {
                return Content($"{loginInfo.Email} - {loginInfo.Password}");
            }
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Register registerInfo)
        {
            if (registerInfo.Email == registerInfo.Password)
            {
                ModelState.AddModelError("", "e-mail и пароль не должны совпадать");
            }
            if (ModelState.IsValid)
            {
                return Content($"{registerInfo.Email} - {registerInfo.Password} - {registerInfo.ConfirmPassword}");
            }
            return RedirectToAction("Index", "Home");
        }
    }
}
