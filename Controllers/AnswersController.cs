using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using QuestionBanksApi.Data;
using QuestionBanksApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionBanksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly QuestionBankAPIDbContext dbContext;
        public AnswersController(QuestionBankAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("{id}",Name ="get-by-question-id")]

        public async Task<IActionResult> GetAnswerByQuestionId(Guid id)
        {
            try
            {
                //var answers = await dbContext.Answer.Include(c => c.Question)
                //    .Where(c => c.Question_Id == id)
                //    .AsNoTracking().ToListAsync();
                var answers = await dbContext.Answer
                    .Include(q => q.Question_Id)
                    .ToListAsync();

                if (answers != null)
                {
                    return Ok(answers);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {

                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAnswers(AddAnwersRequest addAnswersRequest)
        {
            var answers = new Answer
            {
                id = Guid.NewGuid(),
                Question_Id=addAnswersRequest.Question_Id,
                Content = addAnswersRequest.Content,
                Correct = addAnswersRequest.Correct,
                UserId = addAnswersRequest.UserId,
                UpdateDate = addAnswersRequest.UpdateDate
            };
            await dbContext.Answer.AddAsync(answers);
            await dbContext.SaveChangesAsync();
            return Ok(answers);
        }
    }
}
