using System;
using System.Collections.Generic;
using System.Text;
using Question.Domain.CreateAnswerWorkflow;
using static Question.Domain.CreateAnswerWorkflow.CreateAnswerResult;
using CSharp.Choices;

namespace Test.App
{
    class Program_Answer
    {
        static void Main(string[] args)
        {
            DateTime date1 = new DateTime(2019, 10, 19);
            var cmd = new CreateAnswerCmd("You may recover some depth information using stereo-imaging and then recover the original size", "I've also checked", date1);
            var result = CreateAnswer(cmd);

            var createAnswerEvent = result.Match(ProcessAnswerPosted, ProcessAnswerNotPosted, ProcessInvalidAnswer);

            Console.ReadLine();
        }

        private static ICreateAnswerResult ProcessInvalidAnswer(AnswerValidationFailed validationErrors)
        {
            Console.WriteLine("Answer validation failed: ");
            foreach (var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }

        private static ICreateAnswerResult ProcessAnswerNotPosted(AnswerNotPosted answerNotPosted)
        {
            Console.WriteLine($"Answer not posted: {answerNotPosted.Reason}");
            return answerNotPosted;
        }

        private static ICreateAnswerResult ProcessAnswerPosted(AnswerPosted new_answer)
        {
            Console.WriteLine($"Answer {new_answer.AnswerId}");
            Console.WriteLine($"Description {new_answer.Description}");
            return new_answer;
        }

        public static ICreateAnswerResult CreateNewAnswer(CreateAnswerCmd createAnswer)
        {
            if (string.IsNullOrWhiteSpace(createAnswer.DescriptionOfAnswer))
            {
                var errors = new List<string>() { "Invalid Description" };
                return new AnswerValidationFailed(errors);
            }

            if (createAnswer.Date_of_answer == null)
            {
                return new AnswerNotPosted("Missing date!");
            }

            var answerId = Guid.NewGuid();
            var result = new AnswerPosted(answerId, createAnswer.DescriptionOfAnswer);

            return result;
        }
    }
}
