using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nhom2Ki3l2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Nhom2Ki3l2.Models.NhaMay> NhaMay { get; set; }

        public DbSet<Nhom2Ki3l2.Models.KhachHang> KhachHang { get; set; }

        public DbSet<Nhom2Ki3l2.Models.Kho> Kho { get; set; }

        public DbSet<Nhom2Ki3l2.Models.HoaDon> HoaDon { get; set; }

        public DbSet<Nhom2Ki3l2.Models.ChiTietHoaDon> ChiTietHoaDon { get; set; }

        public DbSet<Nhom2Ki3l2.Models.LoaiSanPham> LoaiSanPham { get; set; }

        public DbSet<Nhom2Ki3l2.Models.SanPhamKho> SanPhamKho { get; set; }

        public DbSet<Nhom2Ki3l2.Models.SanPham> SanPham { get; set; }
    }
}
