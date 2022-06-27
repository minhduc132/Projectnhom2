#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using agement2.Models;

namespace agement2.Data
{
    public class agement2Context : DbContext
    {
        public agement2Context (DbContextOptions<agement2Context> options)
            : base(options)
        {
        }

        public DbSet<agement2.Models.QLhocki> QLhocki { get; set; }

        public DbSet<agement2.Models.QLmonhoc> QLmonhoc { get; set; }

        public DbSet<agement2.Models.QLsinhvien> QLsinhvien { get; set; }
    }
}
