namespace WebShop
{
    public class OrderDetail
    {
        public int OrderDetailID { get; set; }

        public int OrderID { get; set; }

        public int ArticleID { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}