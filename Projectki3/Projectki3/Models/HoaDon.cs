using System;
using System.Collections.Generic;

namespace Projectki3.Models
{
    public class HoaDon
    {
        public int Id { get; set; }
        public int IdKH { get; set; }
        public DateTime NgayXuat { get; set; }       
        public string TrangThai { get; set; }
        public double TongTien { get; set; }
        public virtual KhachHang KhachHangs { get; set; }
        public ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }
    }
}
