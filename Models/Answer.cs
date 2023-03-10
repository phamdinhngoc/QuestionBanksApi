using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace QuestionBanksApi.Models
{
    public class Answer
    {
        public Guid id { get; set; }
        public Guid Question_Id { get; set; }
        public string Content { get; set; }
        public int Correct { get; set; }
        public int UserId { get; set; }
        public DateTime UpdateDate { get; set; }


        [JsonIgnore]
        public Question Question { get; set; }
    }
}
