

using System.Collections.Generic;

namespace ServerApi2.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
