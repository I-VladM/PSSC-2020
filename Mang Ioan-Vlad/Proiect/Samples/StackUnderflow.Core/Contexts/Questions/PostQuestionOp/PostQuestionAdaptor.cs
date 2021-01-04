using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Core.Contexts.Questions.PostQuestionOp.PostQuestionResult;

namespace StackUnderflow.Domain.Core.Contexts.Questions.PostQuestionOp
{
    public class PostQuestionAdaptor : Adapter<PostQuestionCmd, IPostQuestionResult, QuestionsWriteContext, QuestionsDependencies>
    {
        public override Task PostConditions(PostQuestionCmd cmd, IPostQuestionResult result, QuestionsWriteContext state)
        {
            return Task.CompletedTask;
        }

        public async override Task<IPostQuestionResult> Work(PostQuestionCmd cmd, QuestionsWriteContext state, QuestionsDependencies dependencies)
        {
            var workflow = from valid in cmd.TryValidate()
                           let t = PostQuestion(state, PostQuestionFromCmd(cmd))
                           select t;

            var result = await workflow.Match(
                Succ: r => r,
                Fail: ex => new QuestionNotPosted(ex.Message)
                );

            return result;
        }

        private IPostQuestionResult PostQuestion(QuestionsWriteContext state, object v)
        {
            string tags = "Compiler";

            return new QuestionPosted(1,"Question Title","Question text", tags);
        }

        private object PostQuestionFromCmd(PostQuestionCmd cmd)
        {
            return new { };
        }
    }
}
