using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question.Domain.PostQuestionWorkflow
{
    [AsChoice]
    public static partial class PostQuestionResult
    {
        public interface IPostQuestionResult { }

        public class QuestionPosted : IPostQuestionResult
        {
            public Guid QuestionId { get; private set; }
            public string Title { get; private set; }
            public string Body { get; private set; }
            public List<string> Tags { get; private set; }
            public int VoteCount { get; private set; }
            public IReadOnlyCollection<VoteEnum> AllVotes { get; private set; }
            public QuestionPosted(Guid questionId, string title, string body, List<string> tags,int votecount,IReadOnlyCollection<VoteEnum>allvotes)
            {
                QuestionId = questionId;
                Title = title;
                Body = body;
                Tags = tags;
                VoteCount = votecount;
                AllVotes = allvotes;
            }
        }

        public class QuestionNotPosted : IPostQuestionResult
        {
            public string Reason { get; set; }

            public QuestionNotPosted(string reason)
            {
                Reason = reason;
            }
        }

        public class QuestionValidationFailed : IPostQuestionResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public QuestionValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}
