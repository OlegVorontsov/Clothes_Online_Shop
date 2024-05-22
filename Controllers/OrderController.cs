using Clothes_Online_Shop.Data;
using Clothes_Online_Shop.DB.Data;
using Clothes_Online_Shop.DB.Models;
using Clothes_Online_Shop.Helpers;
using Clothes_Online_Shop.Models;
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

        [HttpPost]
        public IActionResult Buy(UserDeliveryInfoViewModel userInfo)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Cart", userInfo);
            }
            var existingCart =  cartsRepository.TryGetByUserId(ShopUser.UserId);
            var newOrder = new Order
            {
                UserInfo = Mapping.ToUser(userInfo),
                Items = existingCart.Items
            };
            ordersRepository.Add(newOrder);
            cartsRepository.Clear(ShopUser.UserId);
            return RedirectToAction("Catalog", "Product");
        }
    }
}
