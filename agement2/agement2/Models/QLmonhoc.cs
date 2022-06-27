namespace agement2.Models
{
    public class QLmonhoc
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Semester { get; set; }

        public ICollection<QLdiem> QLdiem { get; set; }
    }
}
