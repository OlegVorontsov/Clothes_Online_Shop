using Clothes_Online_Shop.DB;
using Clothes_Online_Shop.DB.Data;
using Clothes_Online_Shop.DB.Models;
using Clothes_Online_Shop.Helpers;
using Clothes_Online_Shop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Clothes_Online_Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IOrdersRepository _ordersRepository;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IOrdersRepository ordersRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _ordersRepository = ordersRepository;
        }
        public IActionResult Index(string userName)
        {
            var user = _userManager.FindByNameAsync(userName).Result;
            return View(user.ToUserViewModel());
        }

        public IActionResult Edit(UserViewModel editUser)
        {
            var user = _userManager.FindByNameAsync(editUser.Name).Result;
            _userManager.SetEmailAsync(user, editUser.Email).Wait();
            _userManager.SetPhoneNumberAsync(user, editUser.Phone).Wait();
            return RedirectToAction(nameof(Index), new { userName = user.UserName });
        }
        public IActionResult Orders(string userName)
        {
            var orders = _ordersRepository.GetAllByUserName(userName);
            return View(orders.Select(x => x.ToOrderViewModel()).ToList());
        }
        public IActionResult OrderDetails(Guid orderId)
        {
            var order = _ordersRepository.TryGetById(orderId);
            return View(order.ToOrderViewModel());
        }
        public IActionResult Login(string returnUrl)
        {
            return View(new Login { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public IActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var result = _signInManager.PasswordSignInAsync(login.Email, login.Password, login.RememberMe, false).Result;
                if (result.Succeeded)
                {
                    return Redirect(login.ReturnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Неверный логин или пароль");
                }
            }
            return View(login);
        }
        public IActionResult Register(string ReturnUrl)
        {
            return View(new Register() { ReturnUrl = ReturnUrl });
        }
        [HttpPost]
        public IActionResult Register(Register register)
        {
            if (register.Email == register.Password)
            {
                ModelState.AddModelError("", "e-mail и пароль не должны совпадать");
            }
            if (ModelState.IsValid)
            {
                User user = new User { Email = register.Email, UserName = register.Email,  PhoneNumber = register.Phone };
                var result = _userManager.CreateAsync(user, register.Password).Result;
                if (result.Succeeded)
                {
                    _signInManager.SignInAsync(user, false).Wait();
                    TryAssignUserRole(user);
                    return Redirect(register.ReturnUrl ?? "/Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(register);
        }
        private void TryAssignUserRole(User user)
        {
            try
            {
                _userManager.AddToRoleAsync(user, ShopUser.UserRoleName).Wait();
            }
            catch
            {
                //log
            }
        }
        public IActionResult Logout()
        {
            _signInManager.SignOutAsync().Wait();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
