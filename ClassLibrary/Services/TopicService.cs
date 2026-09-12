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

    public IEnumerable<Topic> GetRecentTopics(int topicAmountToDisplay)
    {
        return _context.Topics
            .Include(t => t.TopicResponses)
            .Include(t => t.TopicCategory)
            .OrderByDescending(t => t.CreatedAt).Take(topicAmountToDisplay);
    }

    public Topic GetTopicByTopicId(int id)
    {
        var topic = _context.Topics
            .Include(t => t.TopicCategory)
            .FirstOrDefault(t => t.Id == id);
        return topic;
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

    public IEnumerable<Topic> GetLatestActiveTopics(int topicAmountToDisplay)
    {
        return _context.Topics
            .Include(t => t.TopicResponses)
            .Include(t => t.TopicCategory)
            .OrderByDescending(t => t.TopicResponses.Max(tr => tr.CreatedAt))
            .Take(topicAmountToDisplay);
    }

    public IEnumerable<Topic> GetMostViewedTopics(int topicAmountToDisplay)
    {
        return _context.Topics
            .Include(t => t.TopicResponses)
            .Include(t => t.TopicCategory)
            .OrderByDescending(t => t.Views)
            .Take(topicAmountToDisplay);
    }

    public void DeleteTopicAndResponses(int topicId)
    {
        var topic = _context.Topics.FirstOrDefault(t => t.Id == topicId);
        if (topic == null) {
            return;
        }

        _context.Topics.Remove(topic);
        var topicResponses = _context.TopicsResponses.Where(tr => tr.TopicParent.Id == topicId);
        _context.TopicsResponses.RemoveRange(topicResponses);
        _context.SaveChanges();
    }
}