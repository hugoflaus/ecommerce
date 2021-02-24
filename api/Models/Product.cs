namespace api.Models
{
    public class Product
    {
        public Product(string description, decimal price)
        {
            Description = description;
            Price = price;
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}