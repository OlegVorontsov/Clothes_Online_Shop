using Clothes_Online_Shop.DB.Data;
using Clothes_Online_Shop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Clothes_Online_Shop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepository productsRepository;
        private readonly IImgInfosDBRepository imgInfosRepository;

        public ProductController(IProductsRepository productsRepository, IImgInfosDBRepository imgInfosRepository)
        {
            this.productsRepository = productsRepository;
            this.imgInfosRepository = imgInfosRepository;
        }

        public IActionResult Catalog()
        {
            var productsDB = productsRepository.GetAll();
            var products = new List<ProductViewModel>();
            foreach (var productDB in productsDB)
            {
                var imgInfosDB = imgInfosRepository.GetAllByProductId(productDB.Id);
                var product = new ProductViewModel
                {
                    Id = productDB.Id,
                    Name = productDB.Name,
                    Item = productDB.Item,
                    Cost = productDB.Cost,
                    Size = productDB.Size,
                    Color = productDB.Color,
                    Care = productDB.Care,
                    Fabric = productDB.Fabric,
                    Brand = productDB.Brand,
                    Country = productDB.Country,
                    Description = productDB.Description,
                    ImgList = imgInfosDB,
                    Like = productDB.Like
                };
                products.Add(product);
            }
            return View(products);
        }

        public IActionResult Index(Guid id)
        {
            var productDB = productsRepository.TryGetById(id);
            if (productDB == null)
            {
                object result = $"Товар с id {id} отсутствует";
                return View("Error", result);
            }
            var imgInfosDB = imgInfosRepository.GetAllByProductId(productDB.Id);
            var product = new ProductViewModel
            {
                Id = productDB.Id,
                Name = productDB.Name,
                Item = productDB.Item,
                Cost = productDB.Cost,
                Size = productDB.Size,
                Color = productDB.Color,
                Care = productDB.Care,
                Fabric = productDB.Fabric,
                Brand = productDB.Brand,
                Country = productDB.Country,
                Description = productDB.Description,
                ImgList = imgInfosDB,
                Like = productDB.Like
            };
            return View(product);
        }
    }
}
