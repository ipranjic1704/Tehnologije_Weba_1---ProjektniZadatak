using DataAccessLayer.Model;

namespace DataAccessLayer.Repository
{
    public interface IPlayerRepository
    {
        List<Player> GetAllPlayers();
        Player? GetById(int id);
        Player Create(Player player);
        Player Update(int id, Player player);
        void Delete(int id);
    }
}