using Clothes_Online_Shop.Data;
using Clothes_Online_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clothes_Online_Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersManager usersManager;
        private readonly IRolesRepository rolesRepository;

        public AccountController(IUsersManager usersManager, IRolesRepository rolesRepository)
        {
            this.usersManager = usersManager;
            this.rolesRepository = rolesRepository;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login loginInfo)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Login));
            }
            if (loginInfo.Email == loginInfo.Password)
            {
                ModelState.AddModelError("", "e-mail и пароль не должны совпадать");
            }
            var userAccount = usersManager.TryGetByName(loginInfo.Email);
            if (userAccount == null)
            {
                ModelState.AddModelError("", $"Пользователь {loginInfo.Email} не найден");
            }
            if (userAccount.Password != loginInfo.Password)
            {
                ModelState.AddModelError("", $"Неверный пароль");
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
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
                usersManager.AddUser(new UserAccount
                {
                    Name = registerInfo.Email,
                    Phone = registerInfo.Phone,
                    Password = registerInfo.Password,
                    Role = rolesRepository.GetUserRole()
                });
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return RedirectToAction(nameof(Register));
        }
    }
}
