using DataAccessLayer.Model;

namespace DataAccessLayer.Repository.Interface
{
    public interface IGameRepository
    {
        List<Game> GetAll();
        Game? GetById(int id);
        Game Create(Game game);
        Game Update(int id, Game game);
        void Delete(int id);
    }
}
