using System.Collections.Generic;

namespace ServerAPI2Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float price { get; set; }
      
        public int Quantity { get; set; }
        public int discountPercent { get; set; }   
        public ICollection<OrderProduct> orderProducts { get; set; }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }  
    }
}
