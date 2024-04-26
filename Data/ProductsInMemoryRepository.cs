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
        public void AddProduct(Product product)
        {
            product.ImgPath = "/img/test.jpg";
            products.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = products.FirstOrDefault(p => p.Id == product.Id);
            if (existingProduct == null)
            {
                return;
            }
            existingProduct.Name = product.Name;
            existingProduct.Item = product.Item;
            existingProduct.Cost = product.Cost;
            existingProduct.Size = product.Size;
            existingProduct.Color = product.Color;
            existingProduct.Care = product.Care;
            existingProduct.Fabric = product.Fabric;
            existingProduct.Brand = product.Brand;
            existingProduct.Country = product.Country;
            existingProduct.Description = product.Description;
        }
    }
}
