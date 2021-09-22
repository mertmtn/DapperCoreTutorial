namespace Models
{
    public class Category  
    {
        public string CategoryName { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public Product Urun { get; set; }
    }
}
