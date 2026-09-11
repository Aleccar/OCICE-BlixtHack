using ClassLibrary.Data;
using ClassLibrary.Data.Models;
using ClassLibrary.DTOs;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Services
{
    public class TopicResponseService(BlixtHackDbContext context) : ITopicResponseService
    {
        private readonly BlixtHackDbContext _context = context;

        public IEnumerable<TopicResponse> GetAllTopicResponsesByTopicId(int id)
        {
            var topicResponses = _context.TopicsResponses.Where(r => r.TopicParent.Id == id).OrderBy(r => r.CreatedAt)
                .Reverse();
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

        
        
        public bool DeleteResponseById(int id)
        {
            var response = _context.TopicsResponses.FirstOrDefault(r => r.Id == id);

            if (response == null)
            {
                return false;
            }

            _context.TopicsResponses.Remove(response);
            _context.SaveChanges();
            return true;
        }

        public int GetParentIdByResponseId(int id)
        {
            var topicResponse = _context.TopicsResponses
                .Include(tr => tr.TopicParent)
                .First(tr => tr.Id == id );

            return  topicResponse.TopicParent.Id;
        }
    }
}