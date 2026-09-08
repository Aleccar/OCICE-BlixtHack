using ClassLibrary.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary.Services
{
    public interface ITopicResponseService
    {
        IEnumerable<TopicResponse> GetAllTopicResponsesByTopicId(int id);
    }
}
