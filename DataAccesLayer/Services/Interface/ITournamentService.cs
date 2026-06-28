using DataAccessLayer.Model;

namespace DataAccessLayer.Services.Interface
{
    public interface ITournamentService
    {
        List<Tournament> GetAll();
        Tournament? GetById(int id);
        Tournament? GetWithMatches(int id);
        Tournament Create(Tournament tournament);
        Tournament? Update(int id, Tournament tournament);
        bool Delete(int id);
    }
}
