using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Data
{
    public class ThreadResponse
    {
        public int Id { get; set; }

        public required Thread ThreadParent { get; set; }

        [Required]
        public string CommentBody { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string ResponderAlias { get; set; }
        
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
