using QuizGame.Data.Quizes;
using QuizGame.Data.Quizes.Interfaces;
using QuizGame.Logic.DTO.Players.Interfaces;
using QuizGame.Logic.DTO.Questions.Interfaces;
using QuizGame.Logic.DTO.Quizes.Interfaces;
using QuizGame.Logic.Utils.Enums;

namespace QuizGame.Logic.DTO.Quizes
{
    public class Quiz : IQuiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<IQuestion> Questions { get; set; }
        public Difficulty Difficulty { get; set; }
        public int MinimumCorrect { get; set; }

        public Quiz()
        {

        }
        public Quiz(int id)
        {
            Id = id;
        }
        public Quiz(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Quiz(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public Quiz(int id, string name, string description, Difficulty dif)
        {
            Id = id;
            Name = name;
            Description = description;
            Difficulty = dif;
        }
        public Quiz(int id, string name, string description, Difficulty dif, int minCor)
        {
            Id = id;
            Name = name;
            Description = description;
            Difficulty = dif;
            MinimumCorrect = minCor;
        }

        public List<IQuiz> GetQuizzes()
        {
            IQuizDAL quizDAL = new QuizDAL();
            return quizDAL.GetQuizzes();
        }

        public List<IQuiz> GetCompletedQuizzes(IPlayer p)
        {
            IQuizDAL quizDAL = new QuizDAL();
            return quizDAL.GetCompletedQuizzes(p);
        }
    }
}
