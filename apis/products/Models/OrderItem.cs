namespace MyWebApp.Models
{
    public class OrderItem
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public Product product { get; set; }
    }
}
