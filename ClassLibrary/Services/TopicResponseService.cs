using ClassLibrary.Data;
using ClassLibrary.Data.Models;

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
    }
}
