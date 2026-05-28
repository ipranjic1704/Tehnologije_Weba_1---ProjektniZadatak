using DataAccessLayer.Model;

namespace DataAccessLayer.Repository
{
    public interface IGameRepository
    {
        List<Game> GetAllGames();
        Game? GetById(int id);
        Game Add(Game game);
        Game Update(int id, Game game);
        void Delete(int id);
    }
}
