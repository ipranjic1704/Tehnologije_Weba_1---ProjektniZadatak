using DataAccessLayer.Model;

namespace DataAccessLayer.Services.Interface
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
