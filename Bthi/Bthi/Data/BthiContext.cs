using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bthi.Models;

namespace Bthi.Data
{
    public class BthiContext : DbContext
    {
        public BthiContext (DbContextOptions<BthiContext> options)
            : base(options)
        {
        }

        public DbSet<Bthi.Models.Nhanvien> Nhanvien { get; set; }
    }
}
