using DataAccessLayer.Model;

  namespace DataAccessLayer.Repository
{
    public interface IMatchRepository
    {
        List<Match> GetAll();
        Match? GetById(int id);
        Match Create(Match match);
        Match Update(int id, Match match);
        void Delete(int id);
    }
}