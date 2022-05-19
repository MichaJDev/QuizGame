using QuizGame.Data.Players.Interfaces;
using QuizGame.Logic.DTO.Players;
using QuizGame.Logic.DTO.Players.Interfaces;
using QuizGame.Logic.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Data.Players
{
    public class PlayerDAL : IPlayerDAL
    {
        readonly string conString = Utils.GetConnectionString();

        public void Create(IPlayer p)
        {
            using SqlConnection con = new(conString);
            string query = "INSERT INTO Players (Name,Score) VALUES (@Name,@Score)";
            using SqlCommand cmd = new(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Name", p.Name);
            cmd.Parameters.AddWithValue("@Score", p.Score);
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Succesfully Created Player by Id: {p.Id}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void Delete(IPlayer p)
        {
            using SqlConnection con = new (conString);
            string query = "DELETE FROM Players WHERE Id  @Id";
            using SqlCommand cmd = new(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Id", p.Id);

            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Succesfully Created Player by Id: {p.Id}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public IPlayer Read(int id)
        {
            using SqlConnection con = new(conString);
            string query = "SELECT Id, Name, Score FROM USERS WHERE Id = @Id";
            con.Open();
            IPlayer p = new Player();
            using (SqlCommand cmd = new(query, con))
            {
                cmd.Parameters.AddWithValue("@Id", id);
                SqlDataReader r = cmd.ExecuteReader();
                while (r.Read())
                {
                    p.Id = r.GetInt32(0);
                    p.Name = r.GetString(1);
                    p.Score = r.GetInt32(2);
                }
            }
            return p;
        }

        public void UpdateScore(IPlayer p)
        {
            using SqlConnection con = new(conString);
            string query = "UPDATE Players SET Score = @Score WHERE Id = @Id";
            using SqlCommand cmd = new(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Id", p.Id);
            cmd.Parameters.AddWithValue("@Score", p.Score);
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Succesfully Created Player by Id: {p.Id}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        public void UpdateName(IPlayer p)
        {
            using SqlConnection con = new(conString);
            string query = "UPDATE Players SET Name = @Name WHERE Id = @Id";
            using SqlCommand cmd = new(query, con);
            con.Open();
            cmd.Parameters.AddWithValue("@Id", p.Id);
            cmd.Parameters.AddWithValue("@Name", p.Name);
            try
            {
                cmd.ExecuteNonQuery();
                Console.WriteLine($"Succesfully Updated Player by Id: {p.Id}");
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
    }
}
