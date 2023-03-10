using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class QuestionsController : ControllerBase
    {
        private readonly QuestionBankAPIDbContext dbContext;

        public QuestionsController (QuestionBankAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            return Ok(await dbContext.Questions.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetQuestionById([FromRoute] Guid id)
        {
            var question = await dbContext.Questions.FindAsync(id);
            if(question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> AddQuestion(AddQuestionRequest addQuestionRequest)
        {
            var question = new Question
            {
                id = Guid.NewGuid(),
                Content= addQuestionRequest.Content,
                UserId = addQuestionRequest.UserId,
                UpdateDate = addQuestionRequest.UpdateDate
            };
            await dbContext.Questions.AddAsync(question);
            await dbContext.SaveChangesAsync();
            return Ok(question);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateQuestion([FromRoute] Guid id,UpdateQuestionRequest updateQuestionRequest)
        {
            try
            {
                var question = await dbContext.Questions.FindAsync(id);
                if(question != null)
                {
                    question.Content = updateQuestionRequest.Content;
                    question.UserId = updateQuestionRequest.UserId;
                    question.UpdateDate = updateQuestionRequest.UpdateDate;

                    await dbContext.SaveChangesAsync();
                    return Ok(question);
                }
                else
                {
                    return NotFound();
                }
            }
            catch 
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteQuestion([FromRoute] Guid id)
        {
            var question = await dbContext.Questions.FindAsync(id);
            if (question != null)
            {
                dbContext.Remove(question);
                await dbContext.SaveChangesAsync();
                return Ok(question);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
