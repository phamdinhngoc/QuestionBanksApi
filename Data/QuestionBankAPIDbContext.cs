using Microsoft.EntityFrameworkCore;
using QuestionBanksApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuestionBanksApi.Data
{
    public class QuestionBankAPIDbContext : DbContext
    {
        public QuestionBankAPIDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
