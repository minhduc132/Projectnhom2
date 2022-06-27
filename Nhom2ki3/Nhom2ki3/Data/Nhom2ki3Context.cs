using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nhom2ki3.Models;

namespace Nhom2ki3.Data
{
    public class Nhom2ki3Context : DbContext
    {
        public Nhom2ki3Context (DbContextOptions<Nhom2ki3Context> options)
            : base(options)
        {
        }

        public DbSet<Nhom2ki3.Models.KhachHang> KhachHang { get; set; }

        public DbSet<Nhom2ki3.Models.SanPham> SanPham { get; set; }

        public DbSet<Nhom2ki3.Models.Kho> Kho { get; set; }

        public DbSet<Nhom2ki3.Models.LoaiSanPham> LoaiSanPham { get; set; }

        public DbSet<Nhom2ki3.Models.ChiTietHoaDon> ChiTietHoaDon { get; set; }

        public DbSet<Nhom2ki3.Models.HoaDon> HoaDon { get; set; }

        public DbSet<Nhom2ki3.Models.NhaMay> NhaMay { get; set; }

        public DbSet<Nhom2ki3.Models.SanPhamKho> SanPhamKho { get; set; }
    }
}
