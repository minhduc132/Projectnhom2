using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClientAPI.Models;

namespace ClientAPI.Data
{
    public class ClientAPIContext : DbContext
    {
        public ClientAPIContext (DbContextOptions<ClientAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ClientAPI.Models.Product> Product { get; set; }
    }
}
