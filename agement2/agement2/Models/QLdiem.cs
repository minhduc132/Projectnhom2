using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace agement2.Models
{
    public class QLdiem
    {
        public int Id { get; set; }
        public decimal Theory { get; set; }
        public decimal Practice { get; set; }
        public decimal Exercise { get; set; }

     

        [Display(Name = "QLsinhvien")]
        public int QLsinhvienId { get; set; }

        [ForeignKey("QLsinhvienId")]
        public virtual QLsinhvien QLsinhviens { get; set; }


    }
}
