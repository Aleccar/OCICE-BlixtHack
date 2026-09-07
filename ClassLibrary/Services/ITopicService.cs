using ClassLibrary.Data.Models;

namespace ClassLibrary.Services;

public interface ITopicService {
    IEnumerable<Topic> GetAllTopicsByCategoryId(int id);
    IEnumerable<Topic> GetRecentTopics();
}