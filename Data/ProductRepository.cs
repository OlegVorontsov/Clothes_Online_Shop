using Clothes_Online_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Online_Shop.Data
{
    public class ProductRepository
    {
        private static List<Product> products = new List<Product>()
        {
                new Product ("Зип худи шерпа с капюшоном", "st0171", 1199, 50, "Белый", "деликатная машинная стирка", "80% хлопок 20% полиэстер",
                             "Nike", "USA", "высокое качество по доступной цене", false),
                new Product ("Футболка однотонная", "sp0070", 599, 50, "Белый", "деликатная машинная стирка", "100% хлопок",
                             "Puma", "USA", "легкая и прочная ткань", false),
                new Product ("Джинсы Slim", "sk0500", 2999, 50, "Серый", "машинная стирка", "100% хлопок",
                             "Lee", "USA", "ультра прочная ткань", false)
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
