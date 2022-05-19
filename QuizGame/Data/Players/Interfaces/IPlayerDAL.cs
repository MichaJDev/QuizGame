using QuizGame.Logic.DTO.Players.Interfaces;

namespace QuizGame.Data.Players.Interfaces
{
    internal interface IPlayerDAL
    {
        public IPlayer Read(int id);
        public void Create(IPlayer p);
        public void UpdateScore(IPlayer p);
        public void UpdateName(IPlayer p);
        public void Delete(IPlayer p);
    }
}
