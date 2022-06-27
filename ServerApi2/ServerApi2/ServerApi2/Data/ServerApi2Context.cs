using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServerApi2.Models;

namespace ServerApi2.Data
{
    public class ServerApi2Context : IdentityDbContext<IdentityUser>
    {
        public ServerApi2Context (DbContextOptions<ServerApi2Context> options)
            : base(options)
        {
        }

        public DbSet<ServerApi2.Models.Category> Category { get; set; }

        public DbSet<ServerApi2.Models.Product> Product { get; set; }

        public DbSet<ServerApi2.Models.Order> Order { get; set; }

        public DbSet<ServerApi2.Models.OrderProduct> OrderProduct { get; set; }
    }
}
