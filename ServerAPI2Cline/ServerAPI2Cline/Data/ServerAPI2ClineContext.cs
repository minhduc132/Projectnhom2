using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ServerAPI2Cline.Models;

namespace ServerAPI2Cline.Data
{
    public class ServerAPI2ClineContext : DbContext
    {
        public ServerAPI2ClineContext (DbContextOptions<ServerAPI2ClineContext> options)
            : base(options)
        {
        }

        public DbSet<ServerAPI2Cline.Models.Category> Category { get; set; }
    }
}
