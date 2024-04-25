using System.ComponentModel.DataAnnotations;

namespace Clothes_Online_Shop.Models
{
    public class Product
    {
        private static int instanceCounter = 0;
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите название продукта")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите артикул продукта")]
        public string Item { get; set; }
        [Required(ErrorMessage = "Введите цену продукта")]
        [Range(50, 1000000, ErrorMessage = "Цена от 50 до 1000000 руб.")]
        public decimal Cost { get; set; }
        [Required(ErrorMessage = "Введите размер продукта")]
        [Range(20, 60, ErrorMessage ="Диапазон от 0 до 60")]
        public int Size { get; set; }
        [Required(ErrorMessage = "Введите цвет продукта")]
        public string Color { get; set; }
        [Required(ErrorMessage = "Введите уход за продуктом")]
        public string Care { get; set; }
        [Required(ErrorMessage = "Введите состав продукта")]
        public string Fabric { get; set; }
        [Required(ErrorMessage = "Введите фирму продукта")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "Введите страну-производитель продукта")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Введите описание продукта")]
        public string Description { get; set; }
        public string ImgPath { get; set; }
        public bool Like { get; }
        public Product()
        {
            Id = instanceCounter;
            instanceCounter++;
        }
        public Product(string name,
                       string item,
                       decimal cost,
                       int size,
                       string color,
                       string care,
                       string fabric,
                       string brand,
                       string country,
                       string description,
                       string imgPath,
                       bool like) : this()
        {
            Name = name;
            Item = item;
            Cost = cost;
            Size = size;
            Color = color;
            Care = care;
            Fabric = fabric;
            Brand = brand;
            Country = country;
            Description = description;
            ImgPath = imgPath;
            Like = like;
        }
        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Item}\n{Cost}\n{Size}\n{Color}\n{Care}\n{Fabric}\n{Brand}\n{Country}\n{Description}";
        }
    }
}
