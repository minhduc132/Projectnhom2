using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bt2_aspnetcoreMVC2.Models
{
    public class MonHoc
    {
        public int Id { get; set; }
        public string TenMH { get; set; }
        public int HocKiId { get; set; }
        public virtual HocKi HocKis { get; set; }
        public ICollection<Diem> Diems { get; set; }
    }
}
