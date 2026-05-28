using DataAccessLayer.Model;

  namespace DataAccessLayer.Repository
{
    public interface IMatchRepository
    {
        List<Match> GetAllMatches();
        Match? GetById(int id);
        Match Add(Match match);
        Match Update(int id, Match match);
        void Delete(int id);
    }
}