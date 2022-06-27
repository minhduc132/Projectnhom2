using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
        public int DiscountPersen { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category category { get; set; } 

        public ICollection<OrderProduct> orderProduct { get; set; }
    }
}
