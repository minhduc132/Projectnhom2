using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api3.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Api3.Data
{
    public class Api3Context : IdentityDbContext<IdentityUser>
    {
        public Api3Context (DbContextOptions<Api3Context> options)
            : base(options)
        {
        }

        public DbSet<Api3.Model.Category> Category { get; set; }
    }
}
