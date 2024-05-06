using Clothes_Online_Shop.Data;
using Clothes_Online_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clothes_Online_Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUsersManager usersManager;

        public UserController(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
        }

        public IActionResult Index()
        {
            return View(usersManager.GetAll());
        }
        public IActionResult ChangePassword(string userName)
        {
            var changePassword = new ChangePassword()
            {
                UserName = userName
            };
            return View(changePassword);
        }
        [HttpPost]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            if (changePassword.UserName == changePassword.Password)
            {
                ModelState.AddModelError("", "e-mail и пароль не должны совпадать");
            }
            if (ModelState.IsValid)
            {
                usersManager.ChangePassword(changePassword.UserName, changePassword.Password);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(ChangePassword));
        }
        public IActionResult Remove(string userName)
        {
            usersManager.Remove(userName);
            return RedirectToAction(nameof(Index));
        }
    }
}
