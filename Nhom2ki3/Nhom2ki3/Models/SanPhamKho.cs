namespace Nhom2ki3.Models
{
    public class SanPhamKho
    {
        public int Id { get; set; }
        public int IdSP { get; set; }
        public int IdKho { get; set; }
        public int SoLuong { get; set; }
        public virtual SanPham SanPhams { get; set; }
        public virtual Kho Khos { get; set; }
    }
}
