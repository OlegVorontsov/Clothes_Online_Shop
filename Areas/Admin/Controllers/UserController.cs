using Clothes_Online_Shop.Areas.Admin.Models;
using Clothes_Online_Shop.Data;
using Clothes_Online_Shop.Models;
using Microsoft.AspNetCore.Mvc;

namespace Clothes_Online_Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUsersManager usersManager;
        private readonly IRolesRepository rolesRepository;

        public UserController(IUsersManager usersManager, IRolesRepository rolesRepository)
        {
            this.usersManager = usersManager;
            this.rolesRepository = rolesRepository;
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
        public IActionResult ChangeRole(string userName)
        {
            var changeRole = new ChangeRole()
            {
                UserName = userName
            };
            return View(changeRole);
        }
        [HttpPost]
        public IActionResult ChangeRole(ChangeRole changeRole)
        {
            if (ModelState.IsValid)
            {
                var roleExists = rolesRepository.TryGetByName(changeRole.RoleName);
                if (roleExists != null)
                {
                    usersManager.ChangeRole(changeRole.UserName, roleExists);
                    return RedirectToAction(nameof(Index));
                }
                var roleToAdd = new Role() { Name = changeRole.RoleName };
                rolesRepository.AddRole(roleToAdd);
                usersManager.ChangeRole(changeRole.UserName, roleToAdd);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(ChangeRole));
        }

        public IActionResult Remove(string userName)
        {
            usersManager.Remove(userName);
            return RedirectToAction(nameof(Index));
        }
    }
}
