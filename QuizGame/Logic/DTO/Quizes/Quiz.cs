using QuizGame.Logic.DTO.Questions.Interfaces;
using QuizGame.Logic.DTO.Quizes.Interfaces;
using QuizGame.Logic.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Logic.DTO.Quizes
{
    public class Quiz : IQuiz
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Description { get; set; }
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
        public Quiz(int id, string name, int description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
        public Quiz(int id, string name, int description, Difficulty dif)
        {
            Id = id;
            Name = name;
            Description = description;
            Difficulty = dif;
        }
        public Quiz(int id, string name, int description, Difficulty dif, int minCor)
        {
            Id = id;
            Name = name;
            Description = description;
            Difficulty = dif;
            MinimumCorrect = minCor;
        }

    }
}
