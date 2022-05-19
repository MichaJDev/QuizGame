using QuizGame.Logic.DTO.Questions.Interfaces;

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
