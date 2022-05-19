using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Logic.DTO.Questions.Interfaces
{
    public interface IQuestion
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<string> Answers { get; set; }
        public int CorrectAnswer { get; set; }
        public int Score { get; set; }
    }
}
