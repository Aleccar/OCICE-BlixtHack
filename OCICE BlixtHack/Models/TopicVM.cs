using ClassLibrary.Data.Models;

namespace OCICE_BlixtHack.Models;

public class TopicVM {
    public IEnumerable<Topic> Topics { get; set; }
    public string CategoryName { get; set; }
}