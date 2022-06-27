using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Bt2_aspnetcoreMVC2.Models;

namespace Bt2_aspnetcoreMVC2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Bt2_aspnetcoreMVC2.Models.HocKi> HocKi { get; set; }
        public DbSet<Bt2_aspnetcoreMVC2.Models.MonHoc> MonHoc { get; set; }
        public DbSet<Bt2_aspnetcoreMVC2.Models.SinhVien> SinhVien { get; set; }
        public DbSet<Bt2_aspnetcoreMVC2.Models.Diem> Diem { get; set; }
    }
}
