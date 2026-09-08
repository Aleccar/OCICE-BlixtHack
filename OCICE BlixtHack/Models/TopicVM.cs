using ClassLibrary.Data.Models;
using ClassLibrary.Services;

namespace OCICE_BlixtHack.Models;

public class TopicVM 
{
    public IEnumerable<Topic> Topics { get; set; }
    public string CategoryName { get; set; }
    public TopicDTO? CreateTopicDTO { get; set; }
}