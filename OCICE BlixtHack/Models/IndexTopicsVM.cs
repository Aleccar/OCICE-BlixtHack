using ClassLibrary.Data.Models;

namespace OCICE_BlixtHack.Models;

public class IndexTopicsVM
{
    public IEnumerable<Topic> LatestTopics { get; set; }
    public IEnumerable<Topic> LatestActiveTopics { get; set; }
    public IEnumerable<Topic> MostViewedTopics { get; set; }
}