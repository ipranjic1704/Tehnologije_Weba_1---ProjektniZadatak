using DataAccessLayer.Model;

namespace DataAccessLayer.Repository
{
    public interface ITournamentRepository
    {
        List<Tournament> GetAllTournaments();
        Tournament? GetById(int id);
        Tournament? GetWithMatches(int id);
        Tournament Add(Tournament tournament);
        Tournament Update(int id, Tournament tournament);
        void Delete(int id);
    }
}