using System.Collections.Generic;

namespace Projectki3.Models
{
    public class KhachHang
    {
        public int Id { get; set; }
        public string TenKH { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string TrangThai { get; set; }
        public int CapDo { get; set; }
        public ICollection<HoaDon> HoaDons { get; set; }

    }
}
