using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionBanksApi.Models
{
    public class UpdateQuestionRequest
    {
        public string Content { get; set; }
        public int UserId { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
