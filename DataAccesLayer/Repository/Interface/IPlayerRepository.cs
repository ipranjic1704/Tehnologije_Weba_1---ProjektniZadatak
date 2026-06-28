using DataAccessLayer.Model;

namespace DataAccessLayer.Repository.Interface
{
    public interface IPlayerRepository
    {
        List<Player> GetAll();
        Player? GetById(int id);
        Player Create(Player player);
        Player Update(int id, Player player);
        void Delete(int id);
    }
}