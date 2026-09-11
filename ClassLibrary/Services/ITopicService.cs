using ClassLibrary.Data.Models;

namespace ClassLibrary.Services;

public interface ITopicService {
    IEnumerable<Topic> GetAllTopicsByCategoryId(int id);
    Topic GetTopicByTopicId(int id);

    IEnumerable<Topic> GetRecentTopics(int topicAmountToDisplay);
    void IncrementViewByTopicId(int topicId);
    Topic CreateTopic(TopicDTO topicDTO, Category category);
    IEnumerable<Topic> GetLatestActiveTopics(int topicAmountToDisplay);
}