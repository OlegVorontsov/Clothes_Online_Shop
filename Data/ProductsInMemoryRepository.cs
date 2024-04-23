using Clothes_Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Online_Shop.Data
{
    public class ProductsInMemoryRepository : IProductsRepository
    {
        private List<Product> products = new List<Product>()
        {
                new Product ("Зип худи шерпа с капюшоном", "st0171", 1199, 50, "Белый", "деликатная машинная стирка", "80% хлопок 20% полиэстер",
                             "Stone Island", "USA", "высокое качество по доступной цене",
                             "/img/hudi-white.jpg", false),
                new Product ("Зип худи шерпа с капюшоном", "st0170", 1199, 50, "Черный", "деликатная машинная стирка", "80% хлопок 20% полиэстер",
                             "Stone Island", "USA", "высокое качество по доступной цене",
                             "/img/hudi-black.jpg", false),
                new Product ("Пуховая жилетка", "sk0500", 999, 50, "Бежевый", "ручная стирка", "90% пух 10% полиэстер",
                             "Stone Island", "USA", "лучшее сохранение тепла",
                             "/img/vest.jpg", false)
        };

        public Product TryGetById (int id)
        {
            return products.FirstOrDefault(product => product.Id == id);
        }

        public List<Product> GetAll()
        {
            return products;
        }
    }
}
