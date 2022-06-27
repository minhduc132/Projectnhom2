using System.Collections.Generic;

namespace agement.Models
{
    public class Qlsinhvien
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Phonenumber { get; set; }
        public string Email { get; set; }

        public ICollection<Qldiem> Qldiem { get; set; }

    }
}
