namespace WebShop.Models
{
    public class Article
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public decimal Price { get; set; }
        public decimal Weight { get; set; }
        public string Dimensions { get; set; }
        public string Description { get; set; }
    }
}