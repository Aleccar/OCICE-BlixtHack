using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Data.Models;

public class Topic {
    public int Id { get; set; }

    public required Category TopicCategory { get; set; }
    public List<TopicResponse> TopicResponses { get; set; } = new();

    [Required] [MaxLength(100)] public string Title { get; set; }

    [Required] public string BodyText { get; set; }

    [Required] [MaxLength(50)] public string Alias { get; set; }

    [Required] public int Views  { get; set; }
    
    [Required] public DateTime CreatedAt { get; set; }
}