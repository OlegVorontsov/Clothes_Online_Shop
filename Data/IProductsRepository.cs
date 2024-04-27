﻿using Clothes_Online_Shop.Models;
using System.Collections.Generic;

namespace Clothes_Online_Shop.Data
{
    public interface IProductsRepository
    {
        Product TryGetById(int id);
        List<Product> GetAll();
        void AddProduct(Product product);
        void Update(Product product);
        public void Delete(int productId);
    }
}
