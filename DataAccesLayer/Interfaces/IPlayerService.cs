using DataAccessLayer.Model;

namespace DataAccessLayer.Interfaces
{
    public interface IPlayerService
    {
        List<Player> GetAll();
        Player? GetById(int id);
        Player Create(Player player);
        Player? Update(int id, Player player);
        bool Delete(int id);
    }
}
