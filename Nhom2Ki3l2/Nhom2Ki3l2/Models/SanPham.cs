using System.Collections.Generic;

namespace Nhom2Ki3l2.Models
{
    public class SanPham
    {
        public int Id { get; set; }
        public string TenSP { get; set; }
        public double DonGia { get; set; }
        public string MoTa { get; set; }
        public string HinhAnh { get; set; }
        public string TrangThai { get; set; }
        public int SoLuong { get; set; }
        public int IdLoaiSP { get; set; }
        public virtual LoaiSanPham LoaiSanPhams { get; set; }
        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public ICollection<SanPhamKho> SanPhamKhos { get; set; }
    }
}
