using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.PostQuestionWorkflow
{
    public struct PostQuestionCmd
    {
        
        [Required]
        [MinLength(2),MaxLength(1000)]
        public string Title { get; private set; }

        [Required]
        public string Body { get; set; }

        [Required]
        public List<string> Tags { get; set; }
        
        [Required]
        public int Votes { get; private set; }

        public PostQuestionCmd(string title, string body, List<string> tags,int votes)
        {
            Title = title;
            Body = body;
            Tags = tags;
            Votes=votes;
        }
    }
}
