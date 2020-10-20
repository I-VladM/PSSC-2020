using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.CreateQuestionWorkflow
{
    public struct CreateQuestionCmd
    {
        [Required]
        [StringLength(100, MinimumLength = 3,
        ErrorMessage = "Title should be minimum 3 characters and a maximum of 100 characters")]
        [DataType(DataType.Text)]
        public string Title { get; private set; }
        [Required]
        [DataType(DataType.Text)]
        public string DescriptionOfQuestion { get; private set; }
        [Required]
        public string DomainQuestion { get; private set; }

        public CreateQuestionCmd(string title, string description, string domainQuestion)
        {
            Title = title;
            DescriptionOfQuestion = description;
            DomainQuestion = domainQuestion;
        }
    }
}
