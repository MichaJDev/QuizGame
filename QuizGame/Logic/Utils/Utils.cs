using QuizGame.Logic.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Logic.Utils
{
    public static class Utils
    {
        public static string GetConnectionString()
        {
            return "Server=127.0.0.1;Database=QuizGame;Uid=root;Pwd=;";
        }

        public static string StringifyDifficulty(Difficulty d)
        {
            string difficulty = "";
            switch (d)
            {
                case Difficulty.EASY:
                    difficulty = "Easy";
                    break;
                case Difficulty.MEDIUM:
                    difficulty = "Medium";
                    break;
                case Difficulty.HARD:
                    difficulty = "Hard";
                    break;
            }
            return difficulty;
        }
        public static Difficulty ParseDifficulty(string s)
        {
            Difficulty difficulty = Difficulty.NONE;
            switch (s)
            {
                case "Easy":
                    difficulty = Difficulty.EASY;
                    break;
                case "Medium":
                    difficulty = Difficulty.MEDIUM;
                    break;
                case "Hard":
                    difficulty = Difficulty.HARD;
                    break;
            }
            return difficulty;
        }
    }
}
