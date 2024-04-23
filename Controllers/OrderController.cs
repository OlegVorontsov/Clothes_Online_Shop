using Clothes_Online_Shop.Data;
using Microsoft.AspNetCore.Mvc;

namespace Clothes_Online_Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ICartsRepository cartsRepository;
        private readonly IOrdersRepository ordersRepository;

        public OrderController(ICartsRepository cartsRepository, IOrdersRepository ordersRepository)
        {
            this.cartsRepository = cartsRepository;
            this.ordersRepository = ordersRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Buy()
        {
            var existingCart =  cartsRepository.TryGetByUserId(ShopUser.UserId);
            ordersRepository.Add(existingCart);
            cartsRepository.Clear(ShopUser.UserId);
            return RedirectToAction("Catalog", "Product");
        }
    }
}
