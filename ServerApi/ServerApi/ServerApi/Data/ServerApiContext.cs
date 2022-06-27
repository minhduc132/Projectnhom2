using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerApi.Model;

namespace ServerApi.Data
{
    public class ServerApiContext : DbContext
    {
        public ServerApiContext (DbContextOptions<ServerApiContext> options)
            : base(options)
        {
        }

        public DbSet<ServerApi.Model.Category> Category { get; set; }

        public DbSet<ServerApi.Model.Order> Order { get; set; }

        public DbSet<ServerApi.Model.Product> Product { get; set; }

        public DbSet<ServerApi.Model.OrderProduct> OrderProduct { get; set; }
    }
}
