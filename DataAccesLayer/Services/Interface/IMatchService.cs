using DataAccessLayer.Model;

namespace DataAccessLayer.Services.Interface
{
    public interface IMatchService
    {
        List<Match> GetAll();
        Match? GetById(int id);
        Match Create(Match match);
        Match? Update(int id, Match match);
        bool Delete(int id);
    }
}
