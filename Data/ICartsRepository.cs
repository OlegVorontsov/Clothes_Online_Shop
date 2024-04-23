using Clothes_Online_Shop.Models;

namespace Clothes_Online_Shop.Data
{
    public interface ICartsRepository
    {
        Cart TryGetByUserId(string userId);
        void Add(Product product, string userId);
        void DecreaseAmount(int productId, string userId);
        void DeleteItem(int productId, string userId);
        void Clear(string userId);
    }
}
