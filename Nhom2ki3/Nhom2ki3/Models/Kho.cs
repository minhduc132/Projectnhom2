using System.Collections.Generic;

namespace Nhom2ki3.Models
{
    public class Kho
    {
        public int Id { get; set; }
        public string TenKho { get; set; }
        public string DiaChi { get; set; }
        public ICollection<SanPhamKho> SanPhamKhos { get; set; }

    }
}
