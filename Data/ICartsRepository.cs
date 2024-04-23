using Clothes_Online_Shop.Models;

namespace Clothes_Online_Shop.Data
{
    public interface ICartsRepository
    {
        Cart TryGetByUserId(string userId);
        void Add(Product product, string userId);
    }
}
