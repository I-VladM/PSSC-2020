using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Question.Domain.CreateAnswerWorkflow
{
    public struct CreateAnswerCmd
    {
        [Required]
        [DataType(DataType.Text)]
        public string DescriptionOfAnswer { get; private set; }
        [Required]
        [DataType(DataType.Text)]
        public string Improve_this_answer { get; private set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date_of_answer { get; private set; }

        public CreateAnswerCmd(string description, string improve, DateTime date)
        {
            DescriptionOfAnswer = description;
            Improve_this_answer = improve;
            Date_of_answer = date;
        }
    }
}
