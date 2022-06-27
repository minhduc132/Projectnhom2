using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using APIb1.Model;

namespace APIb1.Data
{
    public class APIb1Context : DbContext
    {
        public APIb1Context (DbContextOptions<APIb1Context> options)
            : base(options)
        {
        }

        public DbSet<APIb1.Model.Category> Category { get; set; }
    }
}
