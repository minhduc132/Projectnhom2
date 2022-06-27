using System;
using System.Collections.Generic;

namespace ServerAPI2Web.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string NameOrder{ get; set; }
        public string DescriptionOrder { get; set; }
        public DateTime OrderDate { get; set; }

        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }

      
        public ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
