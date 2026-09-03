using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Data;

public class Category {
    public int Id { get; set; }

    public List<Thread> Threads { get; set; } = new();

    [Required] [MaxLength(50)] public string Title { get; set; }
}