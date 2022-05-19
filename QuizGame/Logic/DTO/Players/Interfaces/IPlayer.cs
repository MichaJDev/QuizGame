using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame.Logic.DTO.Players.Interfaces
{
    public interface IPlayer
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public int Score { get; set; }
        public bool IsSuperUser { get; set; }
        public bool IsTeacher { get; set; }
        
    }
}
