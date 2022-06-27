using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerAPI2Web.Models;

namespace ServerAPI2Web.Data
{
    public class ServerAPI2WebContext : DbContext
    {
        public ServerAPI2WebContext (DbContextOptions<ServerAPI2WebContext> options)
            : base(options)
        {
        }

        public DbSet<ServerAPI2Web.Models.Category> Category { get; set; }
    }
}
