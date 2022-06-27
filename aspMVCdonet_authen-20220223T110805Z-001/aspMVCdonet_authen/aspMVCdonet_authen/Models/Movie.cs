using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspMVCdonet_authen.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime TeleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
        public string Rating { get; set; }
    }
}
