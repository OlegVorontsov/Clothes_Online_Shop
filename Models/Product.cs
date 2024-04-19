namespace Clothes_Online_Shop.Models
{
    public class Product
    {
        private static int instanceCounter = 0;
        public int Id { get; }
        public string Name { get; }
        public string Item { get; }
        public decimal Cost { get; }
        public int Size { get; }
        public string Color { get; }
        public string Care { get; }
        public string Fabric { get; }
        public string Brand { get; }
        public string Country { get; }
        public string Description { get;}
        public bool Like { get; }
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
                       bool like)
        {
            Id = instanceCounter;
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
            Like = like;
            instanceCounter++;
        }
        public override string ToString()
        {
            return $"{Id}\n{Name}\n{Item}\n{Cost}\n{Size}\n{Color}\n{Care}\n{Fabric}\n{Brand}\n{Country}\n{Description}";
        }
    }
}
