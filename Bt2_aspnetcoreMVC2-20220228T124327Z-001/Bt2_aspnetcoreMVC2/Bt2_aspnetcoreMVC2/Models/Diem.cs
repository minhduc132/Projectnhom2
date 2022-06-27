using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bt2_aspnetcoreMVC2.Models
{
    public class Diem
    {
        public int id { get; set; }
        public int SinhVienId { get; set; }
        public int MonHocId { get; set; }
        public float DiemLT { get; set; }
        public float DiemTH { get; set; }
        public float DiemBT { get; set; }
        public virtual MonHoc MonHocs { get; set; }
        public virtual SinhVien SinhViens { get; set; }
    }
}
