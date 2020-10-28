using System;
using System.Collections.Generic;
using System.Text;
using LanguageExt.Common;
using static Question.Domain.PostQuestionWorkflow.Question;

namespace Question.Domain.PostQuestionWorkflow
{
    public class VerifyQuestioService
    {
        public Result<VerifiedQuestion> VerifyQuestion(UnverifiedQuestion question)
        {
            return new VerifiedQuestion(question.Question, question.Tags);
        }
    }
}
