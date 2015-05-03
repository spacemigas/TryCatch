namespace WebShop.Models
{
    public class OrderDetail
    {
        public Article Article { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}