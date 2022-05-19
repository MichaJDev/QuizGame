using Microsoft.Data.SqlClient;
using QuizGame.Data.Questions.Interfaces;
using QuizGame.Logic.DTO.Questions;
using QuizGame.Logic.DTO.Questions.Interfaces;
using QuizGame.Logic.Utils;

namespace QuizGame.Data.Questions
{
    public class QuestionDAL : IQuestionDAL
    {
        private readonly string conString = Utils.GetConnectionString();
        public void Create(IQuestion q)
        {
            using SqlConnection con = new(conString);
            string query = "INSERT INTO Questions (Description, CorrectAnswer, Answers, Score) WHERE (@Description, @Answer, @Answers ,@Score)";
            con.Open();
            using SqlCommand cmd = new(query, con);
            string answers = "";
            foreach (string s in q.Answers)
            {
                answers += $"{s};";
            }
            cmd.Parameters.AddWithValue("@Description", q.Description);
            cmd.Parameters.AddWithValue("@Awnser", q.CorrectAnswer);
            cmd.Parameters.AddWithValue("@Answers", answers);
            cmd.Parameters.AddWithValue("@Score", q.Score);
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Succesfully Created Question by Id: {q.Id}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public IQuestion Read(int id)
        {

            using SqlConnection con = new(conString);
            string query = "SELECT Description, CorrectAnswer,Answers ,Score FROM Questions WHERE Id = @Id";
            con.Open();
            IQuestion q = new Question();
            SqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                q.Id = id;
                q.Description = r.GetString(1);
                q.CorrectAnswer = r.GetInt32(2);
                //TODO: Change this to object leave for now
                q.Answers = r.GetString(3).Split(';').ToList();
                q.Score = r.GetInt32(4);
            }
            return q;
        }
        public void Update(IQuestion q)
        {
            using SqlConnection con = new(conString);
            string query = "UPDATE Questions SET Description = @desc, CorrectAnswer = @Answer,Answers = @Answers, Score = @Score WHERE Id = @Id";
            con.Open();
            using SqlCommand cmd = new(query, con);
            string answers = "";
            foreach (string s in q.Answers)
            {
                answers += $"{s};";
            }
            cmd.Parameters.AddWithValue("@Id", q.Id);
            cmd.Parameters.AddWithValue("@Description", q.Description);
            cmd.Parameters.AddWithValue("@Awnser", q.CorrectAnswer);
            cmd.Parameters.AddWithValue("@Answers", answers);
            cmd.Parameters.AddWithValue("@Score", q.Score);
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Succesfully Updated Question by Id: {q.Id}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public void Delete(IQuestion q)
        {
            using SqlConnection con = new(conString);
            string query = "DELETE FROM Questions WHERE Id = @Id";
            con.Open();
            using SqlCommand cmd = new(query, con);
            string answers = "";
            foreach (string s in q.Answers)
            {
                answers += $"{s};";
            }
            cmd.Parameters.AddWithValue("@Id", q.Id);
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Succesfully Deleted Question by Id: {q.Id}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public List<IQuestion> GetQuestionsByQuiz(int quizId)
        {
            List<IQuestion> questions = new();
            using SqlConnection con = new(conString);
            string query = "SELECT * FROM Questions WHERE Id = @Id";
            using SqlCommand cmd = new(query, con);
            cmd.Parameters.AddWithValue("@Id", quizId);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                questions.Add(new Question(r.GetInt32(0), r.GetString(1), r.GetString(2).Split(';').ToList(), r.GetInt32(3), r.GetInt32(4)));
            }
            return questions;
        }

    }
}
