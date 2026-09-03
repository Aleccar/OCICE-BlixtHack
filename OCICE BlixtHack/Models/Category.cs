using System.ComponentModel.DataAnnotations;

namespace OCICE_BlixtHack.Models
{
    public class Category
    {
        public int Id { get; set; }

        public List<Thread> Threads { get; set; } = new List<Thread>();

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
    }
}
