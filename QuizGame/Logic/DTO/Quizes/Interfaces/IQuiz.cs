using QuizGame.Logic.DTO.Players.Interfaces;
using QuizGame.Logic.DTO.Questions.Interfaces;
using QuizGame.Logic.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Logic.DTO.Quizes.Interfaces
{
    public interface IQuiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Difficulty Difficulty { get; set; }
        public List<IQuestion> Questions { get; set; }
        public int MinimumCorrect { get; set; }
        public List<IQuiz> GetQuizzes();
        public List<IQuiz> GetCompletedQuizzes(IPlayer p);
    }
}
