using QuizGame.Data.Quizes.Interfaces;
using QuizGame.Logic.DTO.Quizes.Interfaces;
using QuizGame.Logic.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Data.Quizes
{
    public class QuizDAL : IQuizDAL
    {
        private readonly string conString = Utils.GetConnectionString();
        public void Create(IQuiz q)
        {
            using SqlConnection con = new(conString);
            con.Open();
            string query = "INSERT INTO Quizes (Name, Description, Difficulty, MinimumCorrect) VALUES (@Name, @Descriptions, @Difficulty, @MinimumCorrect)";
            using SqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Name", q.Name);
            cmd.Parameters.AddWithValue("@Description", q.Description);
            cmd.Parameters.AddWithValue("@Difficulty", Utils.StringifyDifficulty(q.Difficulty));
            cmd.Parameters.AddWithValue("@MinumumCorrect", q.MinimumCorrect);

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Succesfully Created Quiz by Id: {q.Id}");
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void Delete(IQuiz q)
        {
            using SqlConnection con = new(conString);
            con.Open();
            string query = "INSERT INTO Quizes (Name, Description, Difficulty, MinimumCorrect) VALUES (@Name, @Descriptions, @Difficulty, @MinimumCorrect)";
            using SqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Name", q.Name);
            cmd.Parameters.AddWithValue("@Description", q.Description);
            cmd.Parameters.AddWithValue("@Difficulty", Utils.StringifyDifficulty(q.Difficulty));
            cmd.Parameters.AddWithValue("@MinumumCorrect", q.MinimumCorrect);

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Succesfully Created Quiz by Id: {q.Id}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public IQuiz Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(IQuiz q)
        {
            throw new NotImplementedException();
        }


    }
}
