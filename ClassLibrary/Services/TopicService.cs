using ClassLibrary.Data;
using ClassLibrary.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Services;

public class TopicService(BlixtHackDbContext context) : ITopicService
{
    private readonly BlixtHackDbContext _context = context;

    public IEnumerable<Topic> GetAllTopicsByCategoryId(int id)
    {
        var topics = _context.Topics.Where(t => t.TopicCategory.Id == id).Include(tr => tr.TopicResponses).OrderBy(t => t.CreatedAt).Reverse();
        return topics;
    }

    public IEnumerable<Topic> GetRecentTopics(int amountOfTopics)
    {
        return _context.Topics.OrderByDescending(t => t.CreatedAt).Take(amountOfTopics);
    }

    public Topic GetTopicByTopicId(int id)
    {
        return _context.Topics.First(t => t.Id == id);
    }

    public void IncrementViewByTopicId(int topicId)
    {
        context.Topics.FirstOrDefault(t => t.Id == topicId)!.Views++;
        _context.SaveChanges();
    }

    public Topic CreateTopic(TopicDTO topicDTO, Category category)
    {
        var topicDB = new Topic
        {
            TopicCategory = category,
            Title = topicDTO.Title,
            BodyText = topicDTO.BodyText,
            Alias = topicDTO.Alias,
            Views = 0,
            CreatedAt = DateTime.Now,
        };

        _context.Topics.Add(topicDB);
        _context.SaveChanges();
        return topicDB;
    }
}