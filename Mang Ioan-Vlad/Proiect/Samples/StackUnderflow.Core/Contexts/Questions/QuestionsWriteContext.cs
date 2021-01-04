using StackUnderflow.DatabaseModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions
{
    public class QuestionsWriteContext
    {
        public ICollection<Reply> Replies { get; }
        public QuestionsWriteContext(ICollection<Reply> replies)
        {
            Replies = replies ?? new List<Reply>();
        }

        public ICollection<Question> Question { get; }

        public QuestionsWriteContext(ICollection<Question> questions)
        {
            Question = questions ?? new List<Question>();
        }

       
    }
}
