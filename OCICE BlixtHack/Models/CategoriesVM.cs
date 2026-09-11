using ClassLibrary.Data.Models;

namespace OCICE_BlixtHack.Models;

public class CategoriesVM
{
    public IEnumerable<Category> Categories { get; set; }
    public int Id { get; set; }
    public string Title { get; set; }
}