using System;
using System.Collections.Generic;

namespace ServerApi.Model
{
    public class Order
    {
        public int Id { get; set; } 
        public string Name { get; set; }    
        public string Description { get; set; } 
        public DateTime OrderDate { get; set; }

        public string CustomerName { get; set; }    
        public string CustomerAddress { get; set; }

        public int ProductOrderId { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
