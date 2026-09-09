using ClassLibrary.Data;
using ClassLibrary.Data.Models;
using ClassLibrary.DTOs;

namespace ClassLibrary.Services
{
    public class TopicResponseService(BlixtHackDbContext context) : ITopicResponseService
    {
        private readonly BlixtHackDbContext _context = context;

        public IEnumerable<TopicResponse> GetAllTopicResponsesByTopicId(int id)
        {
            var topicResponses = _context.TopicsResponses.Where(r => r.TopicParent.Id == id).OrderBy(r => r.CreatedAt).Reverse();
            return topicResponses;
        }

        public void CreateResponseByTopic(TopicResponseDTO topicResponseDTO)
        {
            var topicParent = _context.Topics.FirstOrDefault(t => t.Id == topicResponseDTO.TopicParentId);

            var topicResponseDb = new TopicResponse
            {
                TopicParent = topicParent,
                CommentBody = topicResponseDTO.CommentBody,
                ResponderAlias = topicResponseDTO.ResponderAlias,
                CreatedAt = DateTime.Now
            };

            _context.Add(topicResponseDb);
            _context.SaveChanges();
        }
    }
}
