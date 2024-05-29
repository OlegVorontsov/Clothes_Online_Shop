using Clothes_Online_Shop.Areas.Admin.Models;
using Clothes_Online_Shop.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Clothes_Online_Shop.Areas.Admin.Controllers
{
    [Area(ShopUser.AdminRoleName)]
    [Authorize(Roles = ShopUser.AdminRoleName)]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> rolesManager;
        public RoleController(RoleManager<IdentityRole> rolesManager)
        {
            this.rolesManager = rolesManager;
        }
        public IActionResult Index()
        {
            var roles = rolesManager.Roles.ToList();
            return View(roles.Select(r => new RoleViewModel { Name = r.Name}).ToList());
        }
        public IActionResult Remove(string roleName)
        {
            var role = rolesManager.FindByNameAsync(roleName).Result;
            if (role != null)
            {
                rolesManager.DeleteAsync(role).Wait();
            }
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(RoleViewModel role)
        {
            var result = rolesManager.CreateAsync(new IdentityRole(role.Name)).Result;
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(role);
        }
    }
}
