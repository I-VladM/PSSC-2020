using System;
using System.Collections.Generic;
using System.Text;

namespace Tema6.Models
{
    public class Question
    {
        public string Title { get; }
        public string Body { get; }
        public string[] Tags { get; }

        public Question(string title, string body, string[] tags)
        {
            Title = title;
            Body = body;
            Tags = tags;
        }
    }

    public class Reply
    {
        public int QuestionId { get; }
        public string AuthorId { get; }
        public string Answer { get; }

        public Reply(int questionId, string authorId, string answer)
        {
            QuestionId = questionId;
            AuthorId = authorId;
            Answer = answer;
        }
    }
}
