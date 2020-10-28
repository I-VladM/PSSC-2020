using System;
using System.Collections.Generic;
using System.Text;

namespace Question.Domain.PostQuestionWorkflow
{
    [Serializable]
    public class InvalidQuestionException : Exception
    {
        public InvalidQuestionException() { }
        public InvalidQuestionException(string question) : base($"The value \"{question}\" can not be longer than 1000 characters.") { }
    }
}
