using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.PostQuestionWorkflow
{
    [Serializable]
    public class InvalidTagException : Exception
    {
        public InvalidTagException() { }
        public InvalidTagException(List<string> tag) : base($"a question must have at least one tag and no more than 3") { }
    }
}
