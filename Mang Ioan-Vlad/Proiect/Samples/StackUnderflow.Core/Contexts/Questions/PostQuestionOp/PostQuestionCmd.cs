using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Questions.PostQuestionOp
{
    public class PostQuestionCmd
    {
        public PostQuestionCmd()
        {

        }

        public PostQuestionCmd(int questionId, string title, string body, string tags, int votes)
        {
            QuestionId = questionId;
            Title = title;
            Body = body;
            Tags = tags;
            Votes = votes;
        }

        [Required]
        public int QuestionId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [MaxLength(1000)]
        public string Body { get; set; }
        [Required]
        public string Tags { get; set; }
        [Required]
        public int Votes { get; set; }
    }
}
