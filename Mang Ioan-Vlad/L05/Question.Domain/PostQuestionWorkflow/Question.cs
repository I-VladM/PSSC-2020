using System;
using System.Collections.Generic;
using System.Text;
using CSharp.Choices;
using LanguageExt.Common;
namespace Question.Domain.PostQuestionWorkflow
{
    [AsChoice]
    public static partial class Question
    {
        public interface IQuestion { }
        public class UnverifiedQuestion:IQuestion
        {
            public string Question { get;private set; }
            public List<string> Tags { get; private set; }
            private UnverifiedQuestion(string question,List<string>tags)
            {
                Question = question;
                Tags = tags;
            }
            public static Result<UnverifiedQuestion> Create (string question,List<string>tags)
            {
                if(IsQuestionValid(question))
                {
                    if(IsTagValid(tags))
                    {
                        return new UnverifiedQuestion(question, tags);
                    }
                    else
                    {
                        return new Result<UnverifiedQuestion>(new InvalidTagException(tags));
                    }
                }
                else
                {
                    return new Result<UnverifiedQuestion>(new InvalidQuestionException(question));
                }
            }

        }
        private static bool IsQuestionValid(string question)
        {
            if(question.Length>0 && question.Length<=1000)
            {
                return true;
            }
            return false;
        }
        private static bool IsTagValid(List<string>tags)
        {
            if(tags.Count>=1 && tags.Count<=3)
            {
                return true;
            }
            return false;
        }
        public class VerifiedQuestion:IQuestion
        {
            public string Question { get; private set; }
            public List<string> Tags { get; private set; }
            internal VerifiedQuestion(string question, List<string> tags)
            {
                Question = question;
                Tags = tags;
            }
        }
    }
}
