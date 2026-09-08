using ClassLibrary.Data;
using ClassLibrary.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Services
{
    public class TopicResponseService(BlixtHackDbContext context) : ITopicResponseService
    {
        private readonly BlixtHackDbContext _context = context;
        public IEnumerable<TopicResponse> GetAllTopicResponsesByTopicId(int id)
        {
            var topicResponses=_context.TopicsResponses.Where(r=>r.TopicParent.Id == id);
            return topicResponses;
        }
    }
}
