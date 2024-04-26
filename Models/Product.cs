using System.ComponentModel.DataAnnotations;

namespace Clothes_Online_Shop.Models
{
    public class Product
    {
        private static int instanceCounter = 0;
        public int Id { get; set; }
        [Required(ErrorMessage = "обязательное поле*")]
        public string Name { get; set; }
        [Required(ErrorMessage = "обязательное поле*")]
        public string Item { get; set; }
        [Required(ErrorMessage = "обязательное поле*")]
        [Range(50, 1000000, ErrorMessage = "Цена 50...100000 руб.")]
        public decimal Cost { get; set; }
        [Required(ErrorMessage = "обязательное поле*")]
        [Range(20, 60, ErrorMessage ="Диапазон 0...60")]
        public int Size { get; set; }
        [Required(ErrorMessage = "обязательное поле*")]
        public string Color { get; set; }
        [Required(ErrorMessage = "обязательное поле*")]
        public string Care { get; set; }
        [Required(ErrorMessage = "обязательное поле*")]
        public string Fabric { get; set; }
        [Required(ErrorMessage = "обязательное поле*")]
        public string Brand { get; set; }
        [Required(ErrorMessage = "обязательное поле*")]
        public string Country { get; set; }
        [Required(ErrorMessage = "обязательное поле*")]
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
