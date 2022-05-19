using QuizGame.Logic.DTO.Questions.Interfaces;

namespace QuizGame.Logic.DTO.Questions
{
    internal class Question : IQuestion
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public List<string> Answers { get; set; }
        public int CorrectAnswer { get; set; }
        public int Score { get; set; }

        public Question()
        {

        }

        public Question(int id)
        {
            Id = id;
        }
        public Question(int id, string desc)
        {
            Id = id;
            Description = desc;
        }
        public Question(int id, string desc, List<string> answers)
        {
            Id = id;
            Description = desc;
            Answers = answers;
        }
        public Question(int id, string desc, List<string> answers, int correctAnswer)
        {
            Id = id;
            Description = desc;
            Answers = answers;
            CorrectAnswer = correctAnswer;
        }
        public Question(int id, string desc, List<string> answer, int correctAnswer, int score)
        {
            Id = id;
            Description= desc;
            Answers= answer;
            CorrectAnswer = correctAnswer;
            Score = score;
        }
    }
}
