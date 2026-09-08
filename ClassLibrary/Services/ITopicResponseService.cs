using ClassLibrary.Data;
using ClassLibrary.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

public interface ITopicResponseService {
    IEnumerable<TopicResponse> GetAllTopicResponsesByTopicId(int id);
}