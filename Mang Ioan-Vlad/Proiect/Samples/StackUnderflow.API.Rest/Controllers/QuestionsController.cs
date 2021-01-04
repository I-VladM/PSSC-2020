using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using Microsoft.AspNetCore.Mvc;
using StackUnderflow.Domain.Core;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.Domain.Schema.Backoffice.CreateTenantOp;
using StackUnderflow.EF.Models;
using Access.Primitives.EFCore;
using StackUnderflow.Domain.Schema.Backoffice.InviteTenantAdminOp;
using StackUnderflow.Domain.Schema.Backoffice;
using LanguageExt;
using StackUnderflow.Domain.Schema.Questions.CreateAnswerOp;
using StackUnderflow.Domain.Core.Contexts.Questions;
using StackUnderflow.EF;
using Microsoft.EntityFrameworkCore;
using Orleans;
using StackUnderflow.Domain.Core.Contexts.Questions.PostQuestionOp;

namespace StackUnderflow.API.Rest.Controllers
{
    [ApiController]
    [Route("questions")]
    public class QuestionsController : ControllerBase
    {
        private readonly IInterpreterAsync _interpreter;
        private readonly DatabaseContext _dbContext;
        private readonly IClusterClient _client;
        public QuestionsController(IInterpreterAsync interpreter, DatabaseContext dbContext, IClusterClient client)
        {
            _interpreter = interpreter;
            _dbContext = dbContext;
            _client = client;
        }

        [HttpPost("createQuestion")]
        public async Task<IActionResult> CreateQuestion([FromBody] PostQuestionCmd cmd)
        {
            var dep = new QuestionsDependencies();
            var questions = await _dbContext.Questions.ToListAsync();
            var ctx = new QuestionsWriteContext(questions);
            var expr = from createQuestionResult in QuestionsContext.PostQuestion(cmd)
                       select createQuestionResult;
            var r = await _interpreter.Interpret(expr, ctx, dep);

            _dbContext.Questions.Add(new DatabaseModel.Models.Question { QuestionId = cmd.QuestionId, Title=cmd.Title, Body = cmd.Body, Tags=cmd.Tags,Votes=cmd.Votes });
            //var reply = await _dbContext.Replies.Where(r => r.ReplyId == 4).SingleOrDefaultAsync();
            //reply.Body = "Text updated";
            //_dbContext.Replies.Update(reply);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("createReply")]
        public async Task<IActionResult> CreateReply([FromBody] CreateReplyCmd cmd)
        {
            var dep = new QuestionsDependencies();
            var replies = await _dbContext.Replies.ToListAsync();
            var ctx = new QuestionsWriteContext(replies);

            var expr = from createTenantResult in QuestionsContext.CreateReply(cmd)
                       select createTenantResult;

            var r = await _interpreter.Interpret(expr, ctx, dep);

            _dbContext.Replies.Add(new DatabaseModel.Models.Reply { Body = cmd.Body, AuthorUserId = new Guid("9431a4d2-ce83-4ae6-ac13-2f0b2b1d31de"), QuestionId = cmd.QuestionId, ReplyId = 4 });
            //var reply = await _dbContext.Replies.Where(r => r.ReplyId == 4).SingleOrDefaultAsync();
            //reply.Body = "Text updated";
            //_dbContext.Replies.Update(reply);
            await _dbContext.SaveChangesAsync();


            return r.Match(
                succ => (IActionResult)Ok(succ.Body),
                fail => BadRequest("Reply could not be added")
                );
        }
    }
}
