using System.ComponentModel.DataAnnotations;

namespace ClassLibrary.Services;

public class TopicDTO
{
    [Required(ErrorMessage = "Var god och välj en kategori")]
    public int categoryId { get; set; }

    [Required(ErrorMessage = "Var god skriv en rubrik")]
    [MinLength(2, ErrorMessage = "Rubrik måste innehålla minst 2 karaktärer")]
    [MaxLength(100, ErrorMessage = "Rubrik kan inte överskrida 100 karaktärer")]
    public string Title { get; set; }

    [Required(ErrorMessage = "Var god skriv en innehållstext")]
    public string BodyText { get; set; }

    [MinLength(5, ErrorMessage = "Alias måste vara minst 5 karaktärer")]
    [MaxLength(50, ErrorMessage = "Alias får inte vara mer än 50 karaktärer")]
    [Required(ErrorMessage = "Var god skriv ett Alias")]
    public string Alias { get; set; }
}