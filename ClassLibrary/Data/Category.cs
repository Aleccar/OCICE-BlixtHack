using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Data;

public class Category {
    public int Id { get; set; }

    public List<Topic> Topics { get; set; } = new();

    [Required] [MaxLength(50)] public string Title { get; set; }
}