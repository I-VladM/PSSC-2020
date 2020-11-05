using System;
using System.Collections.Generic;
using System.Text;
using Tema6.Models;
using Tema6.Inputs;
using CSharp.Choices;

namespace Tema6.Outputs
{
    [AsChoice]
    public static partial class ValidateReplyResult
    {
        public interface IPublishReplyResult { }

        public class ReplyValid : IPublishReplyResult
        {
            public Reply Reply { get; }

            public ReplyValid(Reply reply)
            {
                Reply = reply;
            }
        }

        public class ReplyInvalid : IPublishReplyResult
        {
            public string Reasons { get; }

            public ReplyInvalid(string reasons)
            {
                Reasons = reasons;
            }
        }
        public class InvalidRequest : IPublishReplyResult
        {
            public string ValidationErrors { get; }
            public ValidateReplyCmd Cmd { get; }
            public InvalidRequest(string validationErrors, ValidateReplyCmd cmd)
            {
                ValidationErrors = validationErrors;
                Cmd = cmd;
            }
        }

    }
}
