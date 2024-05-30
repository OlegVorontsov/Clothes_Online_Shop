using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Clothes_Online_Shop.Models
{
    public class AddProductViewModel
    {
        [Required(ErrorMessage = "название*")]
        public string Name { get; set; }
        [Required(ErrorMessage = "артикул*")]
        public string Item { get; set; }
        [Required(ErrorMessage = "цена*")]
        [Range(50, 1000000, ErrorMessage = "Цена 50...100000 руб.")]
        public decimal Cost { get; set; }
        [Required(ErrorMessage = "размер*")]
        [Range(20, 60, ErrorMessage ="Диапазон 0...60")]
        public int Size { get; set; }
        [Required(ErrorMessage = "цвет*")]
        public string Color { get; set; }
        [Required(ErrorMessage = "уход*")]
        public string Care { get; set; }
        [Required(ErrorMessage = "состав*")]
        public string Fabric { get; set; }
        [Required(ErrorMessage = "фирма*")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "страна*")]
        public string Country { get; set; }
        [Required(ErrorMessage = "описание*")]
        public string Description { get; set; }
        public List<IFormFile> UploadedFiles { get; set; }
    }
}
