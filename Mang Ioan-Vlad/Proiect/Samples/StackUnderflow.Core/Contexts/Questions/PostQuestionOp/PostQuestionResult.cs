using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.PostQuestionOp
{
    [AsChoice]
    public static partial class PostQuestionResult
    {
        public interface IPostQuestionResult { }

        public class QuestionPosted : IPostQuestionResult
        {
            public int QuestionId { get; }
            public string Title { get; } 
            public string Body { get; } 
            public string Tags { get; }
            

            public QuestionPosted(int questionId, string title, string body, string tags)
            {
                QuestionId = questionId;
                Title = title;
                Body = body;
                Tags = tags;       
            }
        }

        public class QuestionNotPosted : IPostQuestionResult
        {
            public string Reason { get; }

            public QuestionNotPosted(string reason)
            {
                Reason = reason;
            }
        }

        public class QuestionValidationFailed : IPostQuestionResult
        {
            public IEnumerable<string> ValidationErrors { get; }

            public QuestionValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}

