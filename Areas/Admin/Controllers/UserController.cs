using Clothes_Online_Shop.Areas.Admin.Models;
using Clothes_Online_Shop.DB;
using Clothes_Online_Shop.DB.Models;
using Clothes_Online_Shop.Helpers;
using Clothes_Online_Shop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Clothes_Online_Shop.Areas.Admin.Controllers
{
    [Area(ShopUser.AdminRoleName)]
    [Authorize(Roles = ShopUser.AdminRoleName)]
    public class UserController : Controller
    {
        private readonly UserManager<User> usersManager;
        private readonly RoleManager<IdentityRole> rolesManager;

        public UserController(UserManager<User> usersManager, RoleManager<IdentityRole> rolesManager)
        {
            this.usersManager = usersManager;
            this.rolesManager = rolesManager;
        }
        public IActionResult Index()
        {
            var users = usersManager.Users.ToList();
            foreach (var user in users)
            {
                var userRolesList = usersManager.GetRolesAsync(user).Result;
                var userRoles = new List<IdentityRole>();
                foreach (var roleString in userRolesList)
                {
                    var role = rolesManager.FindByNameAsync(roleString).Result;
                    userRoles.Add(role);
                }
                user.Roles = userRoles;
            }
            return View(users.Select(u => u.ToUserViewModel()).ToList());
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
                var user = usersManager.FindByNameAsync(changePassword.UserName).Result;
                var newHashPassword = usersManager.PasswordHasher.HashPassword(user, changePassword.Password);
                user.PasswordHash = newHashPassword;
                usersManager.UpdateAsync(user).Wait();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(ChangePassword));
        }
        public IActionResult Edit(string userName)
        {
            var changeUser = new ChangeUser()
            {
                UserName = userName
            };
            return View(changeUser);
        }
        [HttpPost]
        public IActionResult Edit(ChangeUser changeUser)
        {
            if (ModelState.IsValid)
            {
                var user = usersManager.FindByNameAsync(changeUser.UserName).Result;
                user.Email = changeUser.Email;
                user.PhoneNumber = changeUser.Phone;
                usersManager.UpdateAsync(user).Wait();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Edit));
        }
        public IActionResult ChangeRole(string userName)
        {
            var user = usersManager.FindByNameAsync(userName).Result;
            var roles = usersManager.GetRolesAsync(user).Result;
            var allRoles = rolesManager.Roles.ToList();
            var model = new ChangeRoleViewModel
            {
                UserName = user.UserName,
                Roles = roles.Select(r => new RoleViewModel { Name = r }).ToList(),
                AllRoles = allRoles.Select(r => new RoleViewModel { Name = r.Name }).ToList()
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult ChangeRole(string userName, Dictionary<string, bool> userRolesViewModel)
        {
            var selectedInViewRoles = userRolesViewModel.Select(x => x.Key);
            var user = usersManager.FindByNameAsync(userName).Result;
            var roles = usersManager.GetRolesAsync(user).Result;
            //убираем текущие роли у пользователя
            usersManager.RemoveFromRolesAsync(user, roles).Wait();
            usersManager.AddToRolesAsync(user, selectedInViewRoles).Wait();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Remove(string userName)
        {
            var user = usersManager.FindByNameAsync(userName).Result;
            usersManager.DeleteAsync(user).Wait();
            return RedirectToAction(nameof(Index));
        }
    }
}
