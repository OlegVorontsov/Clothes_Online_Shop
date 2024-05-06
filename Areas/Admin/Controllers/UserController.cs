using Clothes_Online_Shop.Data;
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
        public IActionResult Remove(string userName)
        {
            usersManager.Remove(userName);
            return RedirectToAction(nameof(Index));
        }
    }
}
