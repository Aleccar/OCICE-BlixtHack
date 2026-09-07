using ClassLibrary.Data;
using ClassLibrary.Data.Models;

namespace ClassLibrary.Services;

public class TopicService(BlixtHackDbContext context) : ITopicService {
    private readonly BlixtHackDbContext _context = context;

    public IEnumerable<Topic> GetAllTopicsByCategoryId(int id) {
        var topics = _context.Topics.Where(t => t.TopicCategory.Id == id);
        return topics;
    }

    public IEnumerable<Topic> GetRecentTopics() {
        throw new NotImplementedException();
    }
}