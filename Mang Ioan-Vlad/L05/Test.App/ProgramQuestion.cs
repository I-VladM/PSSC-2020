using LanguageExt;
using Question.Domain.PostQuestionWorkflow;
using System;
using System.Collections.Generic;
using System.Net;
using static Question.Domain.PostQuestionWorkflow.PostQuestionResult;
using static Question.Domain.PostQuestionWorkflow.Question;

namespace Test.App
{
    class ProgramQuestion
    {
        static void Main(string[] args)
        {
            List<string> tags = new List<string> { "C++", "C" };
            
             var result= UnverifiedQuestion.Create("What are the differences between C and C++?", tags);

            result.Match(
                Succ: question =>
                {
                    StartQuestion(question);
                    Console.WriteLine("Able to vote ");
                    return Unit.Default;
                },
                Fail : ex =>
                {
                    Console.WriteLine($"Invalid question.Reason:{ex.Message}");
                    return Unit.Default;
                }
                
                );

            Console.ReadLine();
        }
        private static void StartQuestion(UnverifiedQuestion question)
        {
            var verifiedQuestionResult = new VerifyQuestioService().VerifyQuestion(question);
            verifiedQuestionResult.Match(
                verifiedQuestion =>
                {
                    new VoteService().SendVote(verifiedQuestion);
                    return Unit.Default;
                },
                ex =>
                {
                    Console.WriteLine("Impossible to vote");
                    return Unit.Default;
                }
                );
        }
        
    }
}
