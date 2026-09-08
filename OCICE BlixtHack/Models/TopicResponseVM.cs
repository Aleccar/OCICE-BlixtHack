using ClassLibrary.Data.Models;

namespace OCICE_BlixtHack.Models;

public class TopicResponseVM {
    public IEnumerable<TopicResponse> TopicResponses { get; set; }
    public Topic Topic { get; set; }
}