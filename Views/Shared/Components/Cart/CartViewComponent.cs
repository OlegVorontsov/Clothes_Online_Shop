using Clothes_Online_Shop.DB.Data;
using Clothes_Online_Shop.Helpers;
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
            var cartViewModel = Mapping.ToCartViewModel(cart);
            var ProductsCount = cartViewModel?.ProductsCount ?? 0;
            return View("Cart", ProductsCount);
        }

    }
}
