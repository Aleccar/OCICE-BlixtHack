using ClassLibrary.Data.Models;
using ClassLibrary.DTOs;

public interface ITopicResponseService
{
    IEnumerable<TopicResponse> GetAllTopicResponsesByTopicId(int id);

    void CreateResponseByTopic(TopicResponseDTO topicResponseDTO);
    
    bool DeleteResponseById(int id);
    
    int GetParentIdByResponseId(int id);
}