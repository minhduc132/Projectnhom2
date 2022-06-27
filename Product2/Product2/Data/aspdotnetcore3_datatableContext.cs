using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using aspdotnetcore3_datatable.Models;

namespace aspdotnetcore3_datatable.Data
{
    public class aspdotnetcore3_datatableContext : DbContext
    {
        public aspdotnetcore3_datatableContext (DbContextOptions<aspdotnetcore3_datatableContext> options)
            : base(options)
        {
        }

        public DbSet<aspdotnetcore3_datatable.Models.Category> Category { get; set; }

        public DbSet<aspdotnetcore3_datatable.Models.Product> Product { get; set; }
    }
}
