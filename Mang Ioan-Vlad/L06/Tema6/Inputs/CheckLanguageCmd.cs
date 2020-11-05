using LanguageExt.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tema6.Inputs
{
    public class CheckLanguageCmd
    {
        [Required]
        public string Text { get; }

        public CheckLanguageCmd(string text)
        {
            Text = text;
        }


        public static Result<CheckLanguageCmd> Create(string text)
        {
            if (text.Length >= 10 && text.Length <= 500)
                return new CheckLanguageCmd(text);
            else
                return new Result<CheckLanguageCmd>(new InvalidReplyException(text));
        }
    }
}
