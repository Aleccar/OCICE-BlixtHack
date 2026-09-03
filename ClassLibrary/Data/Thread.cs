using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Data;

public class Thread {
    public int Id { get; set; }

    public required Category ThreadCategory { get; set; }
    public List<ThreadResponse> ThreadResponses { get; set; } = new();

    [Required] [MaxLength(100)] public string Title { get; set; }

    [Required] public string BodyText { get; set; }

    [Required] [MaxLength(50)] public string Alias { get; set; }

    [Required] public DateTime CreatedAt { get; set; }
}