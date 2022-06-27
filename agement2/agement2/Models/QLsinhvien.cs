namespace agement2.Models
{
    public class QLsinhvien
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public decimal Phonenumber { get; set; }
        public string? Email { get; set; }

        public ICollection<QLdiem> QLdiem { get; set; }
    }
}
