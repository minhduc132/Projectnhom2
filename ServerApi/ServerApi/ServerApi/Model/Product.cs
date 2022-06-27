using System.Collections.Generic;

namespace ServerApi.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float price { get; set; }
         public virtual Category Category { get; set; } 
        public int Quantity { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
