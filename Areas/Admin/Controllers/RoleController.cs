using Clothes_Online_Shop.Areas.Admin.Models;
using Clothes_Online_Shop.Data;
using Microsoft.AspNetCore.Mvc;

namespace Clothes_Online_Shop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRolesRepository rolesRepository;

        public RoleController(IRolesRepository rolesRepository)
        {
            this.rolesRepository = rolesRepository;
        }

        public IActionResult Index()
        {
            var roles = rolesRepository.GetAll();
            return View(roles);
        }
        public IActionResult Remove(string roleName)
        {
            rolesRepository.Remove(roleName);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Role role)
        {
            if (rolesRepository.TryGetByName(role.Name) != null)
            {
                ModelState.AddModelError("", $"{role.Name} уже есть!");
            }
            if (ModelState.IsValid)
            {
                rolesRepository.AddRole(role);
                return RedirectToAction(nameof(Index));
            }
            return View(role);
        }
    }
}
