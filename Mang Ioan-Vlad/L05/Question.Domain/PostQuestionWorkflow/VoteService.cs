using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static Question.Domain.PostQuestionWorkflow.PostQuestionResult;
using static Question.Domain.PostQuestionWorkflow.Question;

namespace Question.Domain.PostQuestionWorkflow
{
    public class VoteService
    {
        public Task SendVote(VerifiedQuestion question)
        {
            return Task.CompletedTask;
        }
    }
}
