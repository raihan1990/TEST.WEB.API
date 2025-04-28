namespace TEST.WEB.API.Models
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } 

        public int CategoryId { get; set; } // Foreign key to Category       
        public Category Category { get; set; } = null!;  // Navigation property
    }
}
