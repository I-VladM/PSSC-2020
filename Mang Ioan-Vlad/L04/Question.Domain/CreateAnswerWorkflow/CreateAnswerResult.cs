using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Question.Domain.CreateAnswerWorkflow
{
    /// <summary>
    /// SUM type:
    /// </summary>
    [AsChoice]
    public static partial class CreateAnswerResult
    {
        /// <summary>
        /// Marker interface
        /// </summary>
        public interface ICreateAnswerResult
        {

        }
        /// <summary>
        /// PRODUCT TYPE
        /// </summary>
        public class AnswerPosted : ICreateAnswerResult
        {
            public Guid AnswerId { get; private set; }
            public string Description { get; private set; }

            public AnswerPosted(Guid answerId, string description)
            {
                AnswerId = answerId;
                Description = description;
            }
        }
        /// <summary>
        /// PRODUCT TYPE
        /// </summary>
        public class AnswerNotPosted : ICreateAnswerResult
        {
            public string Reason { get; set; }

            public AnswerNotPosted(string reason)
            {
                Reason = reason;
            }
        }
        /// <summary>
        /// PRODUCT TYPE
        /// </summary>
        public class AnswerValidationFailed : ICreateAnswerResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public AnswerValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}
