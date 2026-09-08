using ClassLibrary.Data.Models;

namespace ClassLibrary.Services;

public interface ITopicResponseService {
    IEnumerable<TopicResponse> GetAllTopicResponsesByTopicId(int id);
}