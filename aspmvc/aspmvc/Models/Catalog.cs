using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace aspmvc.Models
{
    public class Catalog
    {
        public int Id { get; set; }

        [MaxLength(200)]

        public string Title { get; set; }
    }
}

