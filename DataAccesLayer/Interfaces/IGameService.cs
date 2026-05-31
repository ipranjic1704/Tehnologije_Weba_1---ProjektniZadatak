using DataAccessLayer.Model;

namespace DataAccessLayer.Interfaces
{
    public interface IGameService
    {
        List<Game> GetAll();
        Game? GetById(int id);
        Game Create(Game game);
        Game? Update(int  id, Game game);
        bool Delete(int id);
    }
}
