using ClassLibrary.Data;
using ClassLibrary.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Services;

public class TopicService(BlixtHackDbContext context) : ITopicService {
    private readonly BlixtHackDbContext _context = context;

    public IEnumerable<Topic> GetAllTopicsByCategoryId(int id) {
        var topics = _context.Topics.Where(t => t.TopicCategory.Id == id).Include(tr => tr.TopicResponses).OrderBy(t => t.CreatedAt).Reverse();
        return topics;
    }

    public IEnumerable<Topic> GetRecentTopics() {
        throw new NotImplementedException(); //TODO
    }

    public Topic GetTopicByTopicId(int id)
    {
        var topic = _context.Topics.FirstOrDefault(t => t.Id == id);
        return topic;
    }

    public void IncrementViewByTopicId(int topicId) {
        context.Topics.FirstOrDefault(t => t.Id == topicId)!.Views++;
        _context.SaveChanges();
    }
}