namespace agement2.Models
{
    public class QLhocki
    {
        public int Id { get; set; }
         public string? Name { get; set; }


        public ICollection<QLdiem> QLdiems { get; set; }
    }
}
