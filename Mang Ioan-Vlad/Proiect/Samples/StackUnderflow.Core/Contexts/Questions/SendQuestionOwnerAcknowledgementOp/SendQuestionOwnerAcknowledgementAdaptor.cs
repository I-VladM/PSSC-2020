using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknowledgementOp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Schema.Questions.SendQuestionOwnerAcknowledgementOp.SendQuestionOwnerAcknowledgementResult;

namespace StackUnderflow.Domain.Core.Contexts.Questions.SendQuestionOwnerAcknowledgementOp
{
    public class SendQuestionOwnerAcknowledgementAdaptor : Adapter<SendQuestionOwnerAcknowledgementCmd, ISendQuestionOwnerAcknowledgementResult, QuestionsWriteContext, QuestionsDependencies>
    {
        public override Task PostConditions(SendQuestionOwnerAcknowledgementCmd cmd, ISendQuestionOwnerAcknowledgementResult result, QuestionsWriteContext state)
        {
            return Task.CompletedTask;
        }

        public async override Task<ISendQuestionOwnerAcknowledgementResult> Work(SendQuestionOwnerAcknowledgementCmd cmd, QuestionsWriteContext state, QuestionsDependencies dependencies)
        {
            var workflow = from valid in cmd.TryValidate()
                           let t = SendQuestionOwnerAck(state, SendQuestionOwnerAcknowledgementFromCmd(cmd))
                           select t;

            var result = await workflow.Match(
                Succ: r => r,
                Fail: ex => new AcknowledgementNotSent(ex.Message)
                );

            return result;
        }

        private ISendQuestionOwnerAcknowledgementResult SendQuestionOwnerAck(QuestionsWriteContext state, object v)
        {
            return new AcknowledgementSent(1, 2);
        }

        private object SendQuestionOwnerAcknowledgementFromCmd(SendQuestionOwnerAcknowledgementCmd cmd)
        {
            return new { };
        }
    }
}
