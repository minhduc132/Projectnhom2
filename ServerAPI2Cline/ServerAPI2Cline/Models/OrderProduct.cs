namespace ServerAPI2Cline.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId  {get; set; }
        public int Quantity { get; set; }
        public Product product { get; set; }
        public Order order { get; set; }    

    }
}
