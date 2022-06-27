using System.Collections.Generic;

namespace ServerApi.Model
{
    public class Category
    {

        public int Id { get; set; }
        public string Name { get; set; }    
        public int description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
