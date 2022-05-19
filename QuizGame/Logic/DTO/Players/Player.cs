using QuizGame.Logic.DTO.Players.Interfaces;

namespace QuizGame.Logic.DTO.Players
{
    public class Player : IPlayer

    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public bool IsSuperUser { get; set; }
        public bool IsTeacher { get; set; }

        public Player()
        {

        }

        public Player(int id)
        {
            Id = id;
        }

        public Player(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Player(int id, string name, int score)
        {
            Id = id;
            Name = name;
            Score = score;
        }
        public Player(int id, string name, int score, bool isSuper)
        {
            Id = id;
            Name = name;
            Score = score;
            IsSuperUser = isSuper;
        }
        public Player(int id, string name, int score, bool isSuper, bool isTeacher)
        {
            Id = id;
            Name = name;
            Score = score;
            IsSuperUser = isSuper;
            IsTeacher = isTeacher;
        }
    }
}
