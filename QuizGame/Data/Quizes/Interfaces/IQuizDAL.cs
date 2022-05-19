using QuizGame.Logic.DTO.Players.Interfaces;
using QuizGame.Logic.DTO.Quizes.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Data.Quizes.Interfaces
{
    public interface IQuizDAL
    {
        public void Create(IQuiz q);
        public IQuiz Read(int id);
        public void Update(IQuiz q);
        public void Delete(IQuiz q);
        public List<IQuiz> GetQuizzes();
        public List<IQuiz> GetCompletedQuizzes(IPlayer p);
    }
}
