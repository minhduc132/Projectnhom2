#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using aspdotnetcore2.Models;

namespace aspdotnetcore2.Data
{
    public class aspdotnetcore2Context : DbContext
    {
        public aspdotnetcore2Context (DbContextOptions<aspdotnetcore2Context> options)
            : base(options)
        {
        }

        public DbSet<aspdotnetcore2.Models.Movie> Movie { get; set; }
        public DbSet<aspdotnetcore2.Models.Catalog> Catalog { get; set; }
    }
}
