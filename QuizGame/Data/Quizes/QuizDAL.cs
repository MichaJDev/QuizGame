using Microsoft.Data.SqlClient;
using QuizGame.Data.Questions;
using QuizGame.Data.Questions.Interfaces;
using QuizGame.Data.Quizes.Interfaces;
using QuizGame.Logic.DTO.Players.Interfaces;
using QuizGame.Logic.DTO.Questions.Interfaces;
using QuizGame.Logic.DTO.Quizes;
using QuizGame.Logic.DTO.Quizes.Interfaces;
using QuizGame.Logic.Utils;

namespace QuizGame.Data.Quizes
{
    public class QuizDAL : IQuizDAL
    {
        private readonly string conString = Utils.GetConnectionString();
        public void Create(IQuiz q)
        {
            using SqlConnection con = new(conString);
            con.Open();
            string query = "INSERT INTO Quizzes (Name, Description, Difficulty, MinimumCorrect) VALUES (@Name, @Descriptions, @Difficulty, @MinimumCorrect)";
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

        public void Delete(IQuiz q)
        {
            using SqlConnection con = new(conString);
            con.Open();
            string query = "DELETE FROM Quizes WHERE Id = @Id";
            using SqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Id", q.Id);
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Succesfully Deleted Quiz by Id: {q.Id}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public List<IQuiz> GetCompletedQuizzes(IPlayer p)
        {
            List<IQuiz> quizzes = new();
            using SqlConnection con = new(conString);
            string query = "SELECT * FROM Quizzes WHERE Id = @Id";
            con.Open();
            SqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Id", p.Id);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                quizzes.Add(new Quiz(r.GetInt32(0), r.GetString(1), r.GetString(2), Utils.ParseDifficulty(r.GetString(3)), r.GetInt32(4)));
            }
            return quizzes;
        }

        public List<IQuiz> GetQuizzes()
        {
            List<IQuiz> quizzes = new();
            using SqlConnection con = new(conString);
            string query = "SELECT * FROM Quizzes";
            con.Open();
            SqlCommand cmd = new(query, con);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                quizzes.Add(new Quiz(r.GetInt32(0), r.GetString(1), r.GetString(2), Utils.ParseDifficulty(r.GetString(3)), r.GetInt32(4)));
            }
            return quizzes;
        }

        public IQuiz Read(int id)
        {
            IQuiz q = new Quiz();
            using SqlConnection con = new(conString);
            string query = "SELECT Name, Desc, Difficulty, MinimumCorrect FROM Quizzes WHERE Id = @Id";
            using SqlCommand cmd = new(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                q = new Quiz(r.GetInt32(0), r.GetString(1), r.GetString(2), Utils.ParseDifficulty(r.GetString(3)), r.GetInt32(4));
            }
            return q;
        }

        public void Update(IQuiz q)
        {
            IQuestionDAL qDal = new QuestionDAL();
            using SqlConnection con = new(conString);
            con.Open();
            string query = "UPDATE Quizzes SET Name = @Name, Description = @Desc, Difficulty = @Difficulty, MinimumCorrect = @MinumumCorrect WHERE Id = @Id";
            using SqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Name", q.Name);
            cmd.Parameters.AddWithValue("@Description", q.Description);
            foreach (IQuestion question in q.Questions)
            {
                qDal.Update(question);
            }
            cmd.Parameters.AddWithValue("@Difficulty", Utils.StringifyDifficulty(q.Difficulty));
            cmd.Parameters.AddWithValue("@MinumumCorrect", q.MinimumCorrect);

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Succesfully Updated Quiz by Id: {q.Id}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }


    }
}
