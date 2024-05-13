using Clothes_Online_Shop.Models;
using System;

namespace Clothes_Online_Shop.Data
{
    public interface ICartsRepository
    {
        Cart TryGetByUserId(string userId);
        void Add(ProductViewModel product, string userId);
        void DecreaseAmount(Guid productId, string userId);
        void DeleteItem(Guid productId, string userId);
        void Clear(string userId);
    }
}
