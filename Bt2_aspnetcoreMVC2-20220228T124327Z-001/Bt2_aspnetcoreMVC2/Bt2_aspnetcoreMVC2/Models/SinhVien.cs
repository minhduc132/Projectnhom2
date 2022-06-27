using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bt2_aspnetcoreMVC2.Models
{
    public class SinhVien
    {
        public int Id { get; set; }
        public string TenSV { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public ICollection<Diem> Diems { get; set; }
    }
}
