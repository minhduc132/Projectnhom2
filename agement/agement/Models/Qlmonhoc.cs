using System.Collections.Generic;

namespace agement.Models
{
    public class Qlmonhoc
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Semester { get; set; }

        public ICollection<Qldiem> Qldiem { get; set; }


    }
}
