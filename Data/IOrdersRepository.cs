using Clothes_Online_Shop.Models;

namespace Clothes_Online_Shop.Data
{
    public interface IOrdersRepository
    {
        public void Add(Order order);
    }
}