using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionBanksApi.Data;
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
        
        //public async Task<IActionResult> GetAnswerByQuestionId(Guid id)
        //{
        //    try
        //    {
        //        var answers = await dbContext.Answer.Include(c => c.Question)
        //            .where(c => c.QuestionId == id).AsNoTracking().ToListAsync();
        //    }
        //    catch 
        //    {

        //        return BadRequest();
        //    }
        //}
    }
}
