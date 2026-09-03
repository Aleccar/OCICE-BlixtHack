using System.ComponentModel.DataAnnotations;

namespace OCICE_BlixtHack.Models
{
    public class ThreadResponse
    {
        public int Id { get; set; }

        public required Thread Thread { get; set; }


        [Required]
        public string CommentBody { get; set; }


        [Required]
        [MaxLength(50)]
        public string ResponderAlias { get; set; }


        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
