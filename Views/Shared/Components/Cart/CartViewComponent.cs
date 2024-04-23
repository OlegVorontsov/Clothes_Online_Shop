using Clothes_Online_Shop.Data;
using Microsoft.AspNetCore.Mvc; 

namespace Clothes_Online_Shop.Views.Shared.ViewComponents.CartViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ICartsRepository cartsRepository;
        public CartViewComponent(ICartsRepository cartsRepository)
        {
            this.cartsRepository = cartsRepository;
        }
        public IViewComponentResult Invoke()
        {
            var cart = cartsRepository.TryGetByUserId(ShopUser.UserId);
            var ProductsCount = cart?.ProductsCount ?? 0;
            return View("Cart", ProductsCount);
        }

    }
}
