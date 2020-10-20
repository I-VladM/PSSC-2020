using System;
using System.Collections.Generic;
using System.Net;
using LanguageExt;
using Question.Domain.CreateQuestionWorkflow;
using static Question.Domain.CreateQuestionWorkflow.CreateQuestionResult;

namespace Test.App
{
    class Program_Question
    {
        static void Main(string[] args)
        {
            var cmd = new CreateQuestionCmd("Tool for lossless image compression", "Is there any tool or web service that I can use so that I give it a directory of uncompressed images(say .gif) and it returns me a directory of images with all of them compressed?", "image-compression");
            var result = CreateQuestion(cmd);

            var createQuestionEvent = result.Match(ProcessQuetionPosted, ProcessQuestionNotPosted, ProcessInvalidQuestion);

            Console.ReadLine();
        }

        private static ICreateQuestionResult ProcessInvalidQuestion(QuestionValidationFailed validationErrors)
        {
            Console.WriteLine("Question validation failed: ");
            foreach (var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }

        private static ICreateQuestionResult ProcessQuestionNotPosted(QuestionNotPosted questionNotPosted)
        {
            Console.WriteLine($"Question not posted: {questionNotPosted.Reason}");
            return questionNotPosted;
        }

        private static ICreateQuestionResult ProcessQuetionPosted(QuestionPosted new_question)
        {
            Console.WriteLine($"Question {new_question.QuestionId}");
            Console.WriteLine($"Description {new_question.Description}");
            return new_question;
        }

        public static ICreateQuestionResult CreateNewQuestion(CreateQuestionCmd createQuestion)
        {
            if (string.IsNullOrWhiteSpace(createQuestion.DescriptionOfQuestion))
            {
                var errors = new List<string>() { "Invalid Description" };
                return new QuestionValidationFailed(errors);
            }

            if (string.IsNullOrEmpty(createQuestion.Title))
            {
                return new QuestionNotPosted("Missing title!");
            }

            var questionId = Guid.NewGuid();
            var result = new QuestionPosted(questionId, createQuestion.DescriptionOfQuestion);

            return result;
        }
    }
}
