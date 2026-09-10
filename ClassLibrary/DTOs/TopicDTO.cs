using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Services;

public class TopicDTO
{
    [Required(ErrorMessage = "Please assign a category!")]
    public int categoryId { get; set; }

    [Required(ErrorMessage = "Please input a title!")]
    [MinLength(2, ErrorMessage = "Title must contain at least 2 letters!")]
    [MaxLength(100, ErrorMessage = "Title can't exceed 100 letters!")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Please input a text!")]
    public string BodyText { get; set; }

    [Required(ErrorMessage = "Please input an Alias!")]
    public string Alias { get; set; }
}