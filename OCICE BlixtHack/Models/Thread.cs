using System.ComponentModel.DataAnnotations;

namespace OCICE_BlixtHack.Models
{
    public class Thread
    {
        public int Id { get; set; }

        public required Category Category { get; set; }
        public List<ThreadResponse> ThreadResponses { get; set; } = new List<ThreadResponse>();

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public string BodyText { get; set; }
        
        
        [Required]
        [MaxLength(50)]
        public string Alias { get; set; }


        [Required]
        public DateTime CreatedAt { get; set; }


    }
}
