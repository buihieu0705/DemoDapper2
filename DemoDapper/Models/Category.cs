namespace DemoDapper.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string? CategoryName { get; set; }

        public bool? Status { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
