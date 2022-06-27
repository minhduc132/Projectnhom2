
using System.Collections.Generic;
namespace ServerAPI2Cline.Models
{
    public class Category 
    {
    
        public int Id { get; set; }
        public string Name { get; set; }
        public int Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
