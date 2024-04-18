using Clothes_Online_Shop.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clothes_Online_Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductRepository repository;

        public ProductController()
        {
            repository = new ProductRepository();
        }
        public string Index(int id)
        {
            var product = repository.TryGetById(id);
            if (product == null)
            {
                return $"Продукта с {id} не существует";
            }
            return product.ToString();
        }
    }
}
