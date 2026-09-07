using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Data;

public class TopicResponse {
    public int Id { get; set; }

    public required Topic TopicParent { get; set; }

    [Required] public string CommentBody { get; set; }

    [Required] [MaxLength(50)] public string ResponderAlias { get; set; }

    [Required] public DateTime CreatedAt { get; set; }
}