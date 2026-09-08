using ClassLibrary.Data.Models;

public interface ITopicResponseService
{
    IEnumerable<TopicResponse> GetAllTopicResponsesByTopicId(int id);
}