using QuizGame.Logic.DTO.Questions.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Data.Questions.Interfaces
{
    public interface IQuestionDAL
    {
        public void Create(IQuestion q);
        public IQuestion Read(int id);
        public void Update(IQuestion q);
        public void Delete(IQuestion q);
        public List<IQuestion> GetQuestionsByQuiz(int quizId);
    }
}
