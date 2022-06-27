using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace agement.Models
{
    public class Qldiem
    {
        public decimal Theory { get; set; }
        public decimal Practice { get; set; }
        public decimal Exercise { get; set; }


        [Display(Name = "Qlsinhvien")]
        public int QlsinhvienId { get; set; }

        [ForeignKey("QlsinhvienId")]
        public virtual Qlsinhvien Qlsinhviens { get; set; }


    }
}
