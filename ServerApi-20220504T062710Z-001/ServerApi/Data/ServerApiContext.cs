using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServerApi.Models;

namespace ServerApi.Data
{
    public class ServerApiContext : IdentityDbContext<IdentityUser>
    {
        public ServerApiContext (DbContextOptions<ServerApiContext> options)
            : base(options)
        {
        }

        public DbSet<ServerApi.Models.Category> Category { get; set; }

        public DbSet<ServerApi.Models.Product> Product { get; set; }

        public DbSet<ServerApi.Models.Order> Order { get; set; }

        public DbSet<ServerApi.Models.OrderProduct> OrderProduct { get; set; }
    }
}
