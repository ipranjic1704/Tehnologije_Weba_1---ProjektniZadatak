using DataAccessLayer.Model;

namespace DataAccessLayer.Repository
{
    public interface ITournamentRepository
    {
        List<Tournament> GetAll();
        Tournament? GetById(int id);
        Tournament? GetWithMatches(int id);
        Tournament Create(Tournament tournament);
        Tournament Update(int id, Tournament tournament);
        void Delete(int id);
    }
}