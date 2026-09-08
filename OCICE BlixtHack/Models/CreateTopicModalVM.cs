using ClassLibrary.Data.Models;
using ClassLibrary.Services;

namespace OCICE_BlixtHack.Models;

public class CreateTopicModalVM
{
    public TopicDTO CreateTopicDTO { get; set; } = new();
    public IEnumerable<Category> Categories { get; set; } = new List<Category>();
}