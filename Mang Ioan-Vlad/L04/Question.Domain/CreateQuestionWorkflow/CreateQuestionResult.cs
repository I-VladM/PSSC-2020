using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharp.Choices;

namespace Question.Domain.CreateQuestionWorkflow
{
    /// <summary>
    /// SUM type:
    /// </summary>
    [AsChoice]
    public static partial class CreateQuestionResult
    {
        /// <summary>
        /// Marker interface
        /// </summary>
        public interface ICreateQuestionResult
        {
            
        }
        /// <summary>
        /// PRODUCT TYPE
        /// </summary>
        public class QuestionPosted: ICreateQuestionResult
        {
            public Guid QuestionId { get; private set; }
            public string Description { get; private set; }

            public QuestionPosted(Guid questionId, string description)
            {
                QuestionId = questionId;
                Description = description;
            }
        }
        /// <summary>
        /// PRODUCT TYPE
        /// </summary>
        public class QuestionNotPosted : ICreateQuestionResult
        {
            public string Reason { get; set; }

            public QuestionNotPosted(string reason)
            {
                Reason = reason;
            }
        }
        /// <summary>
        /// PRODUCT TYPE
        /// </summary>
        public class QuestionValidationFailed: ICreateQuestionResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public QuestionValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}
