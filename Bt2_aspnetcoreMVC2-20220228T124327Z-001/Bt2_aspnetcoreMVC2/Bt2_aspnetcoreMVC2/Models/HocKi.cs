using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bt2_aspnetcoreMVC2.Models
{
    public class HocKi
    {
        public int Id { get; set; }
        public string TenKi { get; set; }
        public ICollection<MonHoc> MonHocs { get; set; }
    }
}
