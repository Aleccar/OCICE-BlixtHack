using ClassLibrary.Data;

namespace ClassLibrary.Services;

public interface ITopicService {
    IEnumerable<Topic> GetAllTopicsByCategoryId(int id);
    IEnumerable<Topic> GetRecentTopics();
    void IncrementViewByTopicId(int topicId);
}