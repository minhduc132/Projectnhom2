using System.Collections.Generic;

namespace agement.Models
{
    public class Qlhocki
    {
        public  int Id { get; set; }

        public string Name { get; set; }
        public ICollection<Qldiem> Qldiem { get; set; }

    }
}
